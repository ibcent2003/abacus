using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowHistoryModel : IPayLoadObject
    {
        public WorkFlowHistoryModel(string id, string processId, int order, string initialState, string destinationState)
        {
            Id = id;
            ProcessId = processId;
            Order = order;
            InitialState = initialState;
            DestinationState = destinationState;

        }

        public string Id { get; set; }
        public string ProcessId { get; set; }
        public string Identity { get; set; }
        public string AllowedToEmployeeNames { get; set; }
        public string TransitionTime { get; set; }
        public int Order { get; set; }
        public string InitialState { get; set; }
        public string DestinationState { get; set; }
        public string Command { get; set; }
    }
}
