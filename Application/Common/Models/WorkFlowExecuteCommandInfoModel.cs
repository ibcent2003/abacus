using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowExecuteCommandInfoModel : IPayLoadObject
    {
        public WorkFlowProcessInfoModel ProcessInstance { get; set; }
        public bool WasExecuted { get; set; }
    }
}
