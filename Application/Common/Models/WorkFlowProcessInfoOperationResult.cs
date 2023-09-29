using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowProcessInfoOperationResult : WorkFlowOperationResult, IPayLoadObject
    {
        private WorkFlowProcessInfoModel Data { get; set; }
    }
}
