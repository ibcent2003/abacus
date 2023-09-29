using System.Collections.Generic;
using Wbc.Application.MenuResource.Commands.UpdateResource;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.Application.Permission.Query;
using Wbc.Application.Permission.Query.GetPermission;

namespace Wbc.Application.MenuResource.Query.GetResource
{
    public class ResourceVm
    {
        public IList<ResourceAreaDto> ResourceAreas { get; set; }
        public IList<PermissionDto> Permissions { get; set; }
        public UpdateResourceCommand UpdateCommand { get; set; }
    }
}
