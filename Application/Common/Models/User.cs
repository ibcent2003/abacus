using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class User : IPayLoadObject
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool LockOutEnabled { get; set; }
        public bool TwoFactorEnabled { get; set; }

    }
}
