using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Resource : AuditableEntity
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public virtual ResourceArea Area { get; set; }
        public string ResourcePage { get; set; }
        public string LocalLizationKey { get; set; }
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }

    }
}
