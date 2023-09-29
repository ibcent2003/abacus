using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowGetCommandOperationResult : WorkFlowOperationResult, IPayLoadObject
    {
        public WorkFlowCommandModel Command { get; set; }
    }
}
