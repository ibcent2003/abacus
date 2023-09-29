using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class OrganisationApprovalRole : AuditableEntity
    {
        public OrganisationApprovalRole()
        {
            OrganisationUserApprovalRoles = new List<OrganisationUserApprovalRole>();
        }

        public int Id { get; set; }
        public int? SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
        public string RoleName { get; set; }
        public bool IsInternalUse { get; set; }
        public ICollection<OrganisationUserApprovalRole> OrganisationUserApprovalRoles { get; set; }
        public bool IsActive { get; set; }
    }
}
