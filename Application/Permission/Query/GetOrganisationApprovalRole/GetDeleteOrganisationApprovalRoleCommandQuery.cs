using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Permission.Commands.DeleteOrganisationApprovalRole;

namespace Wbc.Application.Permission.Query.GetOrganisationApprovalRole
{
    public class GetDeleteOrganisationApprovalRoleCommandQuery : IRequest<DeleteOrganisationApprovalRoleCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteOrganisationApprovalRoleCommandQueryHandler : IRequestHandler<GetDeleteOrganisationApprovalRoleCommandQuery, DeleteOrganisationApprovalRoleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetDeleteOrganisationApprovalRoleCommandQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DeleteOrganisationApprovalRoleCommand> Handle(GetDeleteOrganisationApprovalRoleCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrganisationApprovalRoles.FindAsync(request.Id);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin) && entity.SubscriberId.HasValue) throw new NotFoundException(nameof(entity), request.Id);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) return _mapper.Map<DeleteOrganisationApprovalRoleCommand>(entity);

            var orgId = _currentUserService.GetUserOrganisationId();

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

            if (entity.SubscriberId != subscriber.Id) throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<DeleteOrganisationApprovalRoleCommand>(entity);
        }
    }
}
