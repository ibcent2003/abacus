using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Permission.Commands.CreateOrganisationalApprovalRole;

namespace Wbc.Application.Permission.Query.GetOrganisationApprovalRole
{
    public class GetAddOrganisationApprovalRoleCommandQuery : IRequest<CreateOrganisationalApprovalRoleCommand>
    {

    }

    public class GetAddOrganisationApprovalRoleCommandQueryHandler : IRequestHandler<GetAddOrganisationApprovalRoleCommandQuery, CreateOrganisationalApprovalRoleCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _context;

        public GetAddOrganisationApprovalRoleCommandQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<CreateOrganisationalApprovalRoleCommand> Handle(GetAddOrganisationApprovalRoleCommandQuery request, CancellationToken cancellationToken)
        {

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) return new CreateOrganisationalApprovalRoleCommand { IsInternalUse = true };

            var orgId = _currentUserService.GetUserOrganisationId();

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

            return new CreateOrganisationalApprovalRoleCommand
            {
                SubscriberId = subscriber.Id,
                IsInternalUse = false
            };
        }
    }
}
