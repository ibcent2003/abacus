using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class ChangePassword : IPayLoadObject
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
