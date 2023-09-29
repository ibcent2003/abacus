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
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services
{
    public class WorkflowActionProvider : IWorkflowActionProvider
    {
        private readonly Dictionary<string, Action<ProcessInstance, string>> _actions = new Dictionary<string, Action<ProcessInstance, string>>();

        private readonly Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task>> _asyncActions = new Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task>>();

        private readonly Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, bool>> _conditions = new Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, bool>>();

        private readonly Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task<bool>>> _asyncConditions = new Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task<bool>>>();

        public static IServiceProvider ServiceProvider { get; private set; }

        public WorkflowActionProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            _actions.Add("WriteTransitionHistory", WriteTransitionHistory);
            _actions.Add("UpdateTransitionHistory", UpdateTransitionHistory);
        }

        private void UpdateTransitionHistory(ProcessInstance processInstance, string actionParameter)
        {
            if (string.IsNullOrEmpty(processInstance.CurrentCommand))
                return;

            var currentstate = WorkflowInit.Runtime.GetLocalizedStateName(processInstance.ProcessId, processInstance.CurrentState) ?? processInstance.CurrentActivityName;

            var nextState = WorkflowInit.Runtime.GetLocalizedStateName(processInstance.ProcessId, processInstance.ExecutedActivityState) ?? processInstance.ExecutedActivity.Name;

            var command = WorkflowInit.Runtime.GetLocalizedCommandName(processInstance.ProcessId, processInstance.CurrentCommand);

            if (!string.IsNullOrEmpty(processInstance.ExecutedTimer))
            {
                command = $"Timer: {processInstance.ExecutedTimer}";
            }

            if (!string.IsNullOrWhiteSpace(processInstance.IdentityId)) new Guid(processInstance.IdentityId);

            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var doc = dbContext.Documents.Include(x => x.DocumentTransitionHistories).FirstOrDefault(x => x.WorkflowProcessId.Equals(processInstance.ProcessId));

            if (doc == null) return;

            var historyItem = doc.DocumentTransitionHistories.FirstOrDefault(
                    h => !h.TransitionTime.HasValue &&
                         h.InitialState == currentstate && h.DestinationState == nextState);

            var comment = processInstance.GetParameter<string>(CommandParameters.CommentAndRemarks.GetAttributeStringValue());

            if (historyItem == null)
            {
                historyItem = new DocumentTransitionHistory
                {
                    DestinationState = nextState,
                    AllowedToRoles = actionParameter,
                    DocumentId = doc.Id,
                    InitialState = currentstate,
                    Command = command,
                    ProcessId = processInstance.ProcessId
                };

                dbContext.DocumentTransitionHistories.Add(historyItem);

            }

            historyItem.Command = command;
            historyItem.Comment = comment;
            historyItem.TransitionTime = DateTime.Now;

            var result = dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }


        private void WriteTransitionHistory(ProcessInstance processInstance, string actionParameter)
        {
            if (processInstance.IdentityIds == null)
                return;

            var currentstate = WorkflowInit.Runtime.GetLocalizedStateName(processInstance.ProcessId, processInstance.CurrentState);

            if (currentstate == null)
            {
                currentstate = processInstance.CurrentActivityName;
            }

            var nextState = WorkflowInit.Runtime.GetLocalizedStateName(processInstance.ProcessId, processInstance.ExecutedActivityState);

            if (nextState == null)
            {
                nextState = processInstance.ExecutedActivity.Name;
            }


            var command = WorkflowInit.Runtime.GetLocalizedCommandName(processInstance.ProcessId, processInstance.CurrentCommand);

            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var doc = dbContext.Documents.FirstOrDefault(x => x.WorkflowProcessId.Equals(processInstance.ProcessId));

            if (doc == null) return;

            var historyItem = new DocumentTransitionHistory
            {
                DestinationState = nextState,
                AllowedToRoles = actionParameter,
                DocumentId = doc.Id,
                InitialState = currentstate,
                Command = command,
                ProcessId = processInstance.ProcessId
            };

            dbContext.DocumentTransitionHistories.Add(historyItem);

            var result = dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }

        #region Implementation of IWorkflowActionProvider

        public void ExecuteAction(string name, ProcessInstance processInstance, WorkflowRuntime runtime,
            string actionParameter)
        {
            if (_actions.ContainsKey(name))
                _actions[name].Invoke(processInstance, actionParameter);
            else
                throw new NotImplementedException($"Action with name {name} isn't implemented");
        }

        public async Task ExecuteActionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //token.ThrowIfCancellationRequested(); // You can use the transferred token at your discretion
            if (_asyncActions.ContainsKey(name))
                await _asyncActions[name].Invoke(processInstance, runtime, actionParameter, token);
            else
                throw new NotImplementedException($"Async Action with name {name} isn't implemented");
        }

        public bool ExecuteCondition(string name, ProcessInstance processInstance, WorkflowRuntime runtime,
            string actionParameter)
        {
            if (_conditions.ContainsKey(name))
                return _conditions[name].Invoke(processInstance, runtime, actionParameter);

            throw new NotImplementedException($"Condition with name {name} isn't implemented");
        }

        public async Task<bool> ExecuteConditionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //token.ThrowIfCancellationRequested(); // You can use the transferred token at your discretion
            if (_asyncConditions.ContainsKey(name))
                return await _asyncConditions[name].Invoke(processInstance, runtime, actionParameter, token);

            throw new NotImplementedException($"Async Condition with name {name} isn't implemented");
        }

        public bool IsActionAsync(string name, string schemeCode)
        {
            return _asyncActions.ContainsKey(name);
        }

        public bool IsConditionAsync(string name, string schemeCode)
        {
            return _asyncConditions.ContainsKey(name);
        }

        public List<string> GetActions(string schemeCode)
        {
            return _actions.Keys.Union(_asyncActions.Keys).ToList();
        }

        public List<string> GetConditions(string schemeCode)
        {
            return _conditions.Keys.Union(_asyncConditions.Keys).ToList();
        }

        #endregion
    }
}

