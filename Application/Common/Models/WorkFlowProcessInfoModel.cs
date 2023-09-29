using System.Collections.Generic;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowProcessInfoModel : IPayLoadObject
    {
        public WorkFlowProcessInfoModel(string id, string activityName, string schemeCode, int instanceStatus)
        {
            Id = id;
            ActivityName = activityName;
            SchemeCode = schemeCode;
            InstanceStatus = instanceStatus;
        }

        public string Id { get; set; }
        public string StateName { get; set; }
        public string ActivityName { get; set; }
        public string SchemeId { get; set; }
        public string SchemeCode { get; set; }
        public string PreviousState { get; set; }
        public string PreviousStateForDirect { get; set; }
        public string PreviousStateForReverse { get; set; }
        public string PreviousActivity { get; set; }
        public string PreviousActivityForDirect { get; set; }
        public string PreviousActivityForReverse { get; set; }
        public string ParentProcessId { get; set; }
        public string RootProcessId { get; set; }
        public object ProcessParameters { get; set; }
        public int InstanceStatus { get; set; }
        public IList<WorkFlowTransitionModel> Transitions { get; set; }
        public IList<WorkFlowHistoryModel> HistoryItem { get; set; }



    }
}
