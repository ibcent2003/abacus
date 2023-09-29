using System;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Workflow.Query.GetApprovalCommands
{
    public class DocumentTransitionHistoryDto : IMapFrom<DocumentTransitionHistory>
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DateTime? TransitionTime { get; set; }
        public int Order { get; set; }
        public string InitialState { get; set; }
        public string DestinationState { get; set; }
        public string Command { get; set; }
        public Guid? UserId { get; set; }
        public string AllowedToRoles { get; set; }
        public Guid ProcessId { get; set; }
        public string Comment { get; set; }
    }
}
