using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class OrganisationUserApprovalRole : AuditableEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IsInternalUse { get; set; }
        public int? SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}
