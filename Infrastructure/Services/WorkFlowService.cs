using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OptimaJet.Workflow.Core.Runtime;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Infrastructure.Services
{
    public class WorkFlowService : IWorkflowService
    {

        private readonly WorkFlowServiceConfiguration _serviceConfiguration;

        public WorkFlowService(WorkFlowServiceConfiguration serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration;
        }

        #region Obsolete

        public async Task<WorkFlowOperationResult> CreateInstanceApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_serviceConfiguration.WorkFlowServiceBaseUrl}{_serviceConfiguration.CreateInstancePostUrl}{model.ProcessId}";
            return await PostAsync<WorkFlowOperationResult>(model, postUrl, cancellationToken);
        }

        public async Task<WorkFlowProcessInfoOperationResult> GetInstanceInfoApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_serviceConfiguration.WorkFlowServiceBaseUrl}{_serviceConfiguration.GetInstanceInfoPostUrl}{model.ProcessId}";
            return await PostAsync<WorkFlowProcessInfoOperationResult>(model, postUrl, cancellationToken);
        }

        public async Task<WorkFlowGetCommandOperationResult> GetAvailableCommandsApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_serviceConfiguration.WorkFlowServiceBaseUrl}{_serviceConfiguration.GetAvailableCommandsPostUrl}{model.ProcessId}";
            return await PostAsync<WorkFlowGetCommandOperationResult>(model, postUrl, cancellationToken);
        }

        public async Task<WorkFlowExecuteCommandResultModel> ExecuteCommandApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_serviceConfiguration.WorkFlowServiceBaseUrl}{_serviceConfiguration.ExecuteCommandPostUrl}{model.ProcessId}";

            return await PostAsync<WorkFlowExecuteCommandResultModel>(model, postUrl, cancellationToken);
        }

        public async Task<WorkFlowStatesOperationResult> GetAvailableStateToSetApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_serviceConfiguration.WorkFlowServiceBaseUrl}{_serviceConfiguration.GetAvailableStateToSetPostUrl}{model.ProcessId}";

            return await PostAsync<WorkFlowStatesOperationResult>(model, postUrl, cancellationToken);
        }

        public async Task<WorkFlowOperationResult> SetStateApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_serviceConfiguration.WorkFlowServiceBaseUrl}{_serviceConfiguration.SetStatePostUrl}{model.ProcessId}";

            return await PostAsync<WorkFlowStatesOperationResult>(model, postUrl, cancellationToken);
        }

        private static async Task<T> PostAsync<T>(IPayLoadObject model, string url, CancellationToken cancellationToken) where T : IPayLoadObject
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = "application/json";

            httpWebRequest.Method = WebRequestMethods.Http.Post;

            var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());

            await using (streamWriter)
            {
                await streamWriter.WriteAsync(model.Serialize());
            }

            var httpResponse = await httpWebRequest.GetResponseAsync();

            string result = null;

            var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException());

            using (streamReader)
            {
                result = await streamReader.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<T>(result);
        }



        #endregion

        public async Task<bool> CreateWorkflowInstanceAsync(Guid processId, string schemeCode, CancellationToken cancellationToken)
        {
            await WorkflowInit.Runtime.CreateInstanceAsync(schemeCode, processId, cancellationToken);

            return true;
        }

        public async Task<bool> ExecuteCommandAsync(Guid processId, string command, string userId, string comment, CancellationToken cancellationToken)
        {
            var availableCommands = await WorkflowInit.Runtime.GetAvailableCommandsAsync(processId, userId);

            var commandToExecute = availableCommands.FirstOrDefault(x => x.CommandName.Equals(command, StringComparison.CurrentCultureIgnoreCase));

            if (commandToExecute == null) return false;
            var commentParameter = CommandParameters.CommentAndRemarks.GetAttributeStringValue();

            if (commandToExecute.Parameters.Count(p => p.ParameterName == commentParameter) == 1)

                commandToExecute.Parameters.Single(p => p.ParameterName == commentParameter).Value = comment ?? string.Empty;

            var result = await WorkflowInit.Runtime.ExecuteCommandAsync(commandToExecute, userId, userId, cancellationToken);

            return result.WasExecuted;
        }

        public async Task<string> GetCurrentStateAsync(Guid id)
        {

            return await WorkflowInit.Runtime.GetCurrentStateNameAsync(id);

        }

        public async Task<DocumentCommandModel[]> GetAllAvailableCommandsAsync(Guid processId, string identity)
        {
            var result = new List<DocumentCommandModel>();

            var commands = await WorkflowInit.Runtime.GetAvailableCommandsAsync(processId, identity);

            foreach (var workflowCommand in commands)
            {
                if (result.Count(c => c.Key == workflowCommand.CommandName) == 0)
                    result.Add(new DocumentCommandModel() { Key = workflowCommand.CommandName, Value = workflowCommand.LocalizedName, Classifier = workflowCommand.Classifier });
            }
            return result.ToArray();
        }

        public async Task<IList<string>> GetAllActorsForDirectCommandTransition(Guid processId, CancellationToken cancellationToken)
        {
            var actors = await WorkflowInit.Runtime.GetAllActorsForDirectCommandTransitionsAsync(processId, false, null, cancellationToken);
            return actors.ToList();
        }

    }
}
