using System.Collections.Generic;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class ClaimList : PageInfoModel, IPayLoadObject
    {
        public ClaimList()
        {
            Claims = new List<UserClaim>();
        }

        public List<UserClaim> Claims { get; set; }
    }
}
