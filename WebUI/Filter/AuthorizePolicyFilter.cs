using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;

namespace Wbc.WebUI.Filter
{
    public class AuthorizePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly Policies _policies;

        public AuthorizePolicyFilter(IAuthorizationService authorizationService, Policies policies)
        {
            _authorizationService = authorizationService;
            _policies = policies;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var policy = _policies.GetPolicyClaimValues();

            var authorized = await _authorizationService.AuthorizeAsync(context.HttpContext.User, policy.PolicyName);

            if (authorized.Succeeded)
            {
                return;
            }

            context.Result = new ForbidResult();
        }


    }
}
