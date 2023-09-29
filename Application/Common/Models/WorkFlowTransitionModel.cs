using System;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowTransitionModel : IPayLoadObject
    {
        public WorkFlowTransitionModel(Guid processId, string fromActivityName, string toActivityName, WorkFlowTransitionClassifier classifier, string transitionTime)
        {
            this.ProcessId = processId.ToString();
            this.FromStateName = fromActivityName;
            this.ToActivityName = toActivityName;
            this.TransitionClassifier = classifier.GetAttributeStringValue();
            this.TransitionTime = transitionTime;
        }

        public string ProcessId { get; set; }
        public string ActorIdentityId { get; set; }
        public string ExecutorIdentityId { get; set; }
        public string FormActivityName { get; set; }
        public string FromStateName { get; set; }
        public bool IsFinalised { get; set; }
        public string ToActivityName { get; set; }
        public string ToStateName { get; set; }
        public string TransitionClassifier { get; set; }
        public string TransitionTime { get; set; }
        public string TriggerName { get; set; }

    }
}
