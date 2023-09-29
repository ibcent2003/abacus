using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Runtime;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Infrastructure.Services
{
    public class WorkflowRuleProvider : IWorkflowRuleProvider
    {
        private class RuleFunction
        {
            public Func<ProcessInstance, string, IEnumerable<string>> GetFunction { get; set; }
            public Func<ProcessInstance, string, string, bool> CheckFunction { get; set; }

            public Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task<IEnumerable<string>>> GetFunctionAsync { get; set; }
            public Func<ProcessInstance, WorkflowRuntime, string, string, CancellationToken, Task<bool>> CheckFunctionAsync { get; set; }
        }

        private readonly Dictionary<string, RuleFunction> _rules = new Dictionary<string, RuleFunction>();
        private readonly Dictionary<string, RuleFunction> _asyncRules = new Dictionary<string, RuleFunction>();

        public static IServiceProvider ServiceProvider { get; private set; }

        public WorkflowRuleProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            _rules.Add("CheckApprovalRole", new RuleFunction
            {
                CheckFunction = CheckRole,
                GetFunction = GetInRole
            });

            _rules.Add("IsDocumentAuthor", new RuleFunction
            {
                CheckFunction = CheckAuthor,
                GetFunction = GetAuthor
            });

            _rules.Add("WbcApprovalRole", new RuleFunction
            {
                CheckFunction = CheckInternalRole,
                GetFunction = GetInternalRole
            });

        }


        private IEnumerable<string> GetAuthor(ProcessInstance processInstance, string rolename)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var doc = dbContext.Documents.FirstOrDefault(x => x.WorkflowProcessId.Equals(processInstance.ProcessId));

            if (doc == null) return new List<string>();

            return new List<string>
                       {
                           doc.AuthorId

                       };
        }

        private bool CheckAuthor(ProcessInstance processInstance, string username, string roleName)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var doc = dbContext.Documents.FirstOrDefault(x => x.WorkflowProcessId.Equals(processInstance.ProcessId));

            return doc != null && doc.AuthorId.Equals(username);
        }

        private IEnumerable<string> GetInRole(ProcessInstance processInstance, string rolename)
        {
            using var scope = ServiceProvider.CreateScope();

            var ssoService = scope.ServiceProvider.GetRequiredService<ISsoService>();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var userInfo = ssoService.GetUserInfo(CancellationToken.None).Result;

            if (userInfo == null) return new List<string>();

            var orgClaimType = ClaimTypes.SubscriptionClaim.GetAttributeStringValue();

            var organisationClaim = userInfo.Claims.FirstOrDefault(x => x.Type.Equals(orgClaimType));

            if (organisationClaim == null) return new List<string>();

            var orgId = Convert.ToInt32(organisationClaim.Value);

            var localSubscriber = dbContext.Subscribers.FirstOrDefault(x => x.ParentId == orgId);

            if (localSubscriber == null) return new List<string>();

            var role = dbContext.OrganisationApprovalRoles.Include(x => x.OrganisationUserApprovalRoles).FirstOrDefault(x => x.SubscriberId == localSubscriber.Id && x.RoleName.Equals(rolename));

            return role == null ? new List<string>() : role.OrganisationUserApprovalRoles.Select(x => x.UserId).ToList();
        }

        private bool CheckRole(ProcessInstance processInstance, string username, string roleName)
        {
            using var scope = ServiceProvider.CreateScope();

            var ssoService = scope.ServiceProvider.GetRequiredService<ISsoService>();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var userInfo = ssoService.GetUserInfo(CancellationToken.None).Result;

            if (userInfo == null) return false;

            var orgClaimType = ClaimTypes.SubscriptionClaim.GetAttributeStringValue();

            var organisationClaim = userInfo.Claims.FirstOrDefault(x => x.Type.Equals(orgClaimType));

            if (organisationClaim == null) return false;

            var orgId = Convert.ToInt32(organisationClaim.Value);

            var localSubscriber = dbContext.Subscribers.FirstOrDefault(x => x.ParentId == orgId);

            if (localSubscriber == null) return false;

            var orgRole = dbContext.OrganisationApprovalRoles.FirstOrDefault(x => x.SubscriberId == localSubscriber.Id && x.RoleName.Equals(roleName));

            if (orgRole == null) return false;

            return orgRole.OrganisationUserApprovalRoles.Any(x => x.UserId.Equals(username));

        }

        private bool CheckInternalRole(ProcessInstance processInstance, string username, string roleName)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var orgRole = dbContext.OrganisationApprovalRoles.Include(x => x.OrganisationUserApprovalRoles).FirstOrDefault(x => x.RoleName.Equals(roleName) && x.IsInternalUse);

            if (orgRole == null) return false;

            var role = orgRole.OrganisationUserApprovalRoles.Any(x => x.UserId.Equals(username) && x.IsInternalUse);

            return role;
        }

        private IEnumerable<string> GetInternalRole(ProcessInstance processInstance, string rolename)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var role = dbContext.OrganisationApprovalRoles.Include(x => x.OrganisationUserApprovalRoles).FirstOrDefault(x => x.IsInternalUse && x.RoleName.Equals(rolename));

            return role == null ? new List<string>() : role.OrganisationUserApprovalRoles.Select(x => x.UserId).ToList();
        }


        #region Implementation of IWorkflowRuleProvider

        public List<string> GetRules(string schemeCode)
        {
            return _rules.Keys.Union(_asyncRules.Keys).ToList();
        }

        public bool Check(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter)
        {
            if (_rules.ContainsKey(ruleName))
                return _rules[ruleName].CheckFunction(processInstance, identityId, parameter);
            throw new NotImplementedException();
        }

        public virtual async Task<bool> CheckAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter, CancellationToken token)
        {
            //token.ThrowIfCancellationRequested(); // You can use the transferred token at your discretion
            if (_asyncRules.ContainsKey(ruleName))
                return await _asyncRules[ruleName].CheckFunctionAsync(processInstance, runtime, identityId, parameter, token).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetIdentities(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter)
        {
            if (_rules.ContainsKey(ruleName))
                return _rules[ruleName].GetFunction(processInstance, parameter);
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<string>> GetIdentitiesAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter, CancellationToken token)
        {
            //token.ThrowIfCancellationRequested(); // You can use the transferred token at your discretion
            if (_asyncRules.ContainsKey(ruleName))
                return await _asyncRules[ruleName].GetFunctionAsync(processInstance, runtime, parameter, token).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        public bool IsCheckAsync(string ruleName, string schemeCode)
        {
            return _asyncRules.ContainsKey(ruleName);
        }

        public bool IsGetIdentitiesAsync(string ruleName, string schemeCode)
        {
            return _asyncRules.ContainsKey(ruleName);
        }

        #endregion
    }
}
