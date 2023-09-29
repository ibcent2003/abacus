using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.Application.Permission.Query.GetPermission;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Query.GetResource
{
    public class ResourceDto : IMapFrom<Resource>
    {
        public int Id { get; set; }
        public string ResourcePage { get; set; }
        public string LocalLizationKey { get; set; }
        public PermissionDto Permission { get; set; }
        public string PersmissionDescription { get; set; }
        public string AreaName { get; set; }
        public ResourceAreaDto Area { get; set; }
        public int AreaId { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public override string ToString()
        {
            return $"/{Area.AreaName}/{ResourcePage}";
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Resource, ResourceDto>()
                .ForMember(d => d.PersmissionDescription, opt => opt.MapFrom(s => s.Permission.PersmissionDescription))
                .ForMember(x => x.AreaName, opt => opt.MapFrom(s => s.Area.AreaName));

        }
    }
}
