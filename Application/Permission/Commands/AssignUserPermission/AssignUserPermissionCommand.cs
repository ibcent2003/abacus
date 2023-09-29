using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Wbc.Application.Permission.Commands.AssignUserPermission
{
    public class AssignUserPermissionCommand : IRequest<Unit>
    {
        public string UserId { get; set; }
        public string SelectedPermissions { get; set; }
    }

    public class AssignUserPermissionCommandHandler : IRequestHandler<AssignUserPermissionCommand, Unit>
    {
        private readonly ISsoService _ssoService;
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public AssignUserPermissionCommandHandler(ISsoService ssoService, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _ssoService = ssoService;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(AssignUserPermissionCommand request, CancellationToken cancellationToken)
        {
            var userClaims = await _ssoService.GetUserClaimsByUserId(new ApiSearchModel { Id = request.UserId }, cancellationToken);

            var actorOrgId = _currentUserService.GetUserOrganisationId();

            var orgId = userClaims.Claims.FirstOrDefault(x => x.ClaimType.Equals(ClaimTypes.SubscriptionClaim.GetAttributeStringValue()));

            if (orgId == null) throw new NotFoundException(nameof(userClaims), request.UserId);

            if (actorOrgId != Convert.ToInt32(orgId.ClaimValue)) throw new NotFoundException(nameof(userClaims), request.UserId);

            var existingPermissions = _context.UserPermissions.Where(x => x.UserId.Equals(request.UserId));

            _context.UserPermissions.RemoveRange(existingPermissions);

            var newPermissions = request.SelectedPermissions.Split(",").Select(x => Convert.ToInt32(x)).ToList();

            var newPermissionParents = await _context.Permissions.Where(x => newPermissions.Contains(x.Id) && x.DependentPermissionId != null).Select(x => x.DependentPermissionId.Value).ToListAsync(cancellationToken);

            newPermissions.AddRange(newPermissionParents.Where(x => !newPermissions.Contains(x)));

            _context.UserPermissions.AddRange(newPermissions.Select(x => new UserPermission
            {
                PermissionId = x,
                UserId = request.UserId
            }));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
