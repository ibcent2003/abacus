using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class UserClaim : IPayLoadObject
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int ClaimId { get; set; }

    }
}
