using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Permission.Commands.UpdateOrganisationApprovalRole;

namespace Wbc.Application.Permission.Query.GetOrganisationApprovalRole
{
    public class GetUpdateOrganisationApprovalRoleCommandQuery : IRequest<UpdateOrganisationApprovalRoleCommand>
    {
        public int Id { get; set; }
        public int? SubscriberId { get; set; }
        public bool IsInternalUse { get; set; }
    }

    public class GetUpdateOrganisationApprovalRoleCommandQueryHandler : IRequestHandler<GetUpdateOrganisationApprovalRoleCommandQuery, UpdateOrganisationApprovalRoleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetUpdateOrganisationApprovalRoleCommandQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<UpdateOrganisationApprovalRoleCommand> Handle(GetUpdateOrganisationApprovalRoleCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrganisationApprovalRoles.FindAsync(request.Id);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin) && entity.SubscriberId.HasValue) throw new NotFoundException(nameof(entity), request.Id);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) return _mapper.Map<UpdateOrganisationApprovalRoleCommand>(entity);

            var orgId = _currentUserService.GetUserOrganisationId();

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

            if (entity.SubscriberId != subscriber.Id) throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<UpdateOrganisationApprovalRoleCommand>(entity);
        }
    }
}

