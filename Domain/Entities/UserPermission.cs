using Wbc.Domain.Entities;

namespace Wbc.Domain.Entities
{
    public class UserPermission
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

    }
}
