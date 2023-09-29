using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.Permission.Commands.DeletePermission
{
    public class DeletePermissionCommand : IRequest, IMapFrom<Domain.Entities.Permission>
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PersmissionDescription { get; set; }
        public string LocalizationKey { get; set; }
        public bool RequireAdminRole { get; set; }
    }

    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeletePermissionCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Permissions.Where(l => l.Id == request.Id)

                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Permission), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
