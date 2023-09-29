using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class ProcessRequiredDocument : AuditableEntity
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
        public int RequiredDocumentId { get; set; }
        public RequiredDocument RequiredDocument { get; set; }
        public string ProcessCode { get; set; }
        public bool Mandatory { get; set; }
        public bool IsActive { get; set; }
        public int? SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

    }
}
