using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class UserRole : IPayLoadObject
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

    }
}
