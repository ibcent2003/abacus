using System.Collections.Generic;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Query.GetTopResource
{
    public class TopResourceDto : IMapFrom<TopResource>
    {
        public TopResourceDto()
        {
            ResourceAreas = new List<ResourceAreaDto>();
        }
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string LocalizationKey { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public IList<ResourceAreaDto> ResourceAreas { get; set; }
    }
}
