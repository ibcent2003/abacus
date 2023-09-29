using System.Collections.Generic;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class UserQueryListResult : PageInfoModel, IPayLoadObject
    {
        public UserQueryListResult()
        {
            Users = new List<User>();
        }

        public IList<User> Users { get; set; }
    }
}
