using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.Permission.Commands.CreatePermission
{
    public class AddPermissionCommandValidator : AbstractValidator<AddPermissionCommand>
    {
        private readonly IApplicationDbContext _context;
        public AddPermissionCommandValidator(CommonLocalizationService localizationService, IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.PermissionName).NotEmpty().WithName(localizationService.Get("PermissionNamelbl"))
                .MustAsync(BeUniquePermissionName).WithMessage(localizationService.Get("ErrorBeUniquePermissionName"))
                .Must(NotContainSpace)
                .WithMessage(localizationService.Get("ErrorNoSpaceInPermissionNameRes"));

            RuleFor(x => x.LocalizationKey).NotEmpty().WithName(localizationService.Get("LocalizationKeylbl"))
                .MustAsync(BeUniqueLocalizationKey)
                .WithMessage(localizationService.Get("ErrorBeUniqueLocalizationKeyRes"))
                .Must(NotContainSpace).WithMessage(localizationService.Get("ErrorNoSpaceInLocalizationKeyRes"));

            RuleFor(x => x.PersmissionDescription).NotEmpty().WithName(localizationService.Get("PermissionDescriptionlbl"));
            RuleFor(x => x.RequireAdminRole).NotEmpty();
        }

        public async Task<bool> BeUniquePermissionName(string resourcename, CancellationToken cancellationToken)
        {
            return await _context.Permissions
                .AllAsync(l => l.PermissionName != resourcename, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueLocalizationKey(string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.Permissions.AllAsync(x => x.LocalizationKey != localizationKey, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }
    }
}
