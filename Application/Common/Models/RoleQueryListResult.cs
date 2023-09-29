using System.Collections.Generic;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class RoleQueryListResult : PageInfoModel, IPayLoadObject
    {
        public RoleQueryListResult()
        {
            Roles = new List<Role>();
        }

        public IEnumerable<Role> Roles { get; set; }
    }
}
