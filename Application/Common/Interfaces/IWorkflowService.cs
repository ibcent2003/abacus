using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Common.Interfaces
{
    public interface IWorkflowService
    {
        Task<DocumentCommandModel[]> GetAllAvailableCommandsAsync(Guid processId, string identity);
        Task<bool> CreateWorkflowInstanceAsync(Guid processId, string schemeCode, CancellationToken cancellationToken);
        Task<string> GetCurrentStateAsync(Guid processId);
        Task<IList<string>> GetAllActorsForDirectCommandTransition(Guid processId, CancellationToken cancellationToken);
        Task<bool> ExecuteCommandAsync(Guid processId, string command, string userId, string comment, CancellationToken cancellationToken);

        [Obsolete]
        Task<WorkFlowOperationResult> CreateInstanceApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken);
        [Obsolete]
        Task<WorkFlowProcessInfoOperationResult> GetInstanceInfoApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken);
        [Obsolete]
        Task<WorkFlowGetCommandOperationResult> GetAvailableCommandsApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken);
        [Obsolete]
        Task<WorkFlowExecuteCommandResultModel> ExecuteCommandApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken);
        [Obsolete]
        Task<WorkFlowStatesOperationResult> GetAvailableStateToSetApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken);
        [Obsolete]
        Task<WorkFlowOperationResult> SetStateApiAsync(WorkFlowInstanceCreateModel model, CancellationToken cancellationToken);

    }
}
