using Wbc.Application.Common.Mappings;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class PermissionDto : IMapFrom<Domain.Entities.Permission>
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PersmissionDescription { get; set; }
        public string LocalizationKey { get; set; }
        public bool RequireAdminRole { get; set; }
        public int DependentPermissionId { get; set; }
    }
}
