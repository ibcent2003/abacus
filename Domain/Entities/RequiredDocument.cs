using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class RequiredDocument : AuditableEntity
    {
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentFormatString { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
        public bool IsInternalUse { get; set; }
        public string MaximumSize { get; set; }


    }
}
