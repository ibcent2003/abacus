using System.Collections.Generic;
using System.Linq;
using Wbc.Application.Permission.Commands.UpdatePermission;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class PermissionVm
    {
        public PermissionVm()
        {

            PermissionDtos = new List<PermissionDto>();
        }

        public IList<PermissionDto> PermissionDtos { get; set; }
        public UpdatePermissionCommand UpdatePermissionCommand { get; set; }

        public IList<string> ToStringList()
        {

            return PermissionDtos.Select(x => x.PermissionName).ToList();
        }

        public override string ToString()
        {
            return string.Join(",", PermissionDtos.Select(x => x.PermissionName));
        }
    }
}
