using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Permission.Commands.CreatePermission
{
    public class AddPermissionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PersmissionDescription { get; set; }
        public string LocalizationKey { get; set; }
        public bool RequireAdminRole { get; set; }
        public int DependentPermissionId { get; set; }
    }

    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public AddPermissionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Permission
            {
                PermissionName = request.PermissionName,
                IsActive = true,
                PersmissionDescription = request.PersmissionDescription,
                LocalizationKey = request.LocalizationKey,
                RequireAdminRole = request.RequireAdminRole,
                DependentPermissionId = request.DependentPermissionId
            };

            _context.Permissions.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
