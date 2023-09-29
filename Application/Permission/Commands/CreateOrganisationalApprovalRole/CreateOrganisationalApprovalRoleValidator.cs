using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.Permission.Commands.CreateOrganisationalApprovalRole
{
    public class CreateOrganisationalApprovalRoleValidator : AbstractValidator<CreateOrganisationalApprovalRoleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrganisationalApprovalRoleValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
            RuleFor(x => x.RoleName).NotEmpty().WithName(commonLocalizationService.Get("RoleNamelbl")).MustAsync(BeUniqueRoleName).WithMessage(commonLocalizationService.Get("ErrorBeUniqueRoleName"));
        }

        public async Task<bool> BeUniqueRoleName(CreateOrganisationalApprovalRoleCommand request, string resourcename, CancellationToken cancellationToken)
        {

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                return await _context.OrganisationApprovalRoles.AnyAsync(l => l.RoleName == resourcename && l.IsInternalUse, cancellationToken: cancellationToken);
            }

            return !await _context.OrganisationApprovalRoles.AnyAsync(l => l.RoleName == resourcename && l.SubscriberId == request.SubscriberId, cancellationToken: cancellationToken);
        }
    }
}
