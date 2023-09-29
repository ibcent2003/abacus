using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowStatesOperationResult : WorkFlowOperationResult, IPayLoadObject
    {
        public WorkFlowStateModel Data { get; set; }
    }
}
