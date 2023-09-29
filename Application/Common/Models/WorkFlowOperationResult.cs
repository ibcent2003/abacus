using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowOperationResult : IPayLoadObject
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }

    }
}
