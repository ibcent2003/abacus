using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class ResourceArea : AuditableEntity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public TopResource Parent { get; set; }
        public string AreaName { get; set; }
        public string LocalizationKey { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
        public IList<Resource> Resources { get; set; }
        public int Order { get; set; }
    }
}
