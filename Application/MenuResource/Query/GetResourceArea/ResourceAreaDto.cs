using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MenuResource.Query.GetTopResource;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Query.GetResourceArea
{
    public class ResourceAreaDto : IMapFrom<ResourceArea>
    {

        public int Id { get; set; }
        public int ParentId { get; set; }
        public TopResourceDto Parent { get; set; }
        public string ParentName { get; set; }
        public string AreaName { get; set; }
        public string LocalizationKey { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ResourceArea, ResourceAreaDto>().ForMember(d => d.ParentName, opt => opt.MapFrom(s => s.Parent.ResourceName));

        }
    }
}
