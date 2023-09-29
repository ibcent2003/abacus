using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowExecuteCommandResultModel : WorkFlowOperationResult, IPayLoadObject
    {
        public WorkFlowExecuteCommandInfoModel Data { get; set; }

    }
}
