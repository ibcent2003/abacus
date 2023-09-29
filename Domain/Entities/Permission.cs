using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Permission : AuditableEntity
    {
        public Permission()
        {
            Users = new List<UserPermission>();
            DependentPermissions = new List<Permission>();
        }
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PersmissionDescription { get; set; }
        public string LocalizationKey { get; set; }
        public IList<UserPermission> Users { get; set; }
        public bool IsActive { get; set; }
        public bool RequireAdminRole { get; set; }
        public int? DependentPermissionId { get; set; }
        public Permission DependentPermission { get; set; }
        public IList<Permission> DependentPermissions { get; set; }
    }
}
