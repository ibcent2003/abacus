using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.Permission.Commands.UpdateOrganisationApprovalRole
{
    public class UpdateOrganisationApprovalRoleCommand : IRequest, IMapFrom<Domain.Entities.OrganisationApprovalRole>
    {

        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsInternalUse { get; set; }
        public int? SubscriberId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateOrganisationApprovalRoleCommandHandler : IRequestHandler<UpdateOrganisationApprovalRoleCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrganisationApprovalRoleCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateOrganisationApprovalRoleCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.OrganisationApprovalRoles.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Permission), request.Id);
            }

            entity.RoleName = request.RoleName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
