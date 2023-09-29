using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Permission.Commands.CreateOrganisationalApprovalRole
{
    public class CreateOrganisationalApprovalRoleCommand : IRequest<int>
    {
        public string RoleName { get; set; }
        public bool IsInternalUse { get; set; }
        public int? SubscriberId { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateOrganisationalApprovalRoleCommandHandler : IRequestHandler<CreateOrganisationalApprovalRoleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrganisationalApprovalRoleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<int> Handle(CreateOrganisationalApprovalRoleCommand request, CancellationToken cancellationToken)
        {

            var entity = new OrganisationApprovalRole
            {
                RoleName = request.RoleName,
                SubscriberId = request.SubscriberId,
                IsInternalUse = request.IsInternalUse,
                IsActive = true
            };

            _context.OrganisationApprovalRoles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
