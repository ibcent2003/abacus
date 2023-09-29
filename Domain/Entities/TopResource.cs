using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class TopResource : AuditableEntity
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string LocalizationKey { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public IList<ResourceArea> ResourceAreas { get; set; }
    }
}
