using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Permission.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest, IMapFrom<Domain.Entities.Permission>
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PersmissionDescription { get; set; }
        public string LocalizationKey { get; set; }
        public bool RequireAdminRole { get; set; }
        public int DependentPermissionId { get; set; }
    }

    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePermissionCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {



            var entity = await _context.Permissions.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Permission), request.Id);
            }

            entity.PermissionName = request.PermissionName;
            entity.PersmissionDescription = request.PersmissionDescription;
            entity.LocalizationKey = request.LocalizationKey;
            entity.RequireAdminRole = request.RequireAdminRole;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
