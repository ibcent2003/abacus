using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wbc.Domain.Entities
{
    public class DocumentTransitionHistory
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public DateTime? TransitionTime { get; set; }
        public int Order { get; set; }
        public string InitialState { get; set; }
        public string DestinationState { get; set; }
        public string Command { get; set; }
        public Guid? UserId { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string AllowedToRoles { get; set; }
        public Guid ProcessId { get; set; }
        public string Comment { get; set; }

    }
}
