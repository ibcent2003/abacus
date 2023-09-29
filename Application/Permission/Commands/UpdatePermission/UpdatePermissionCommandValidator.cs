using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.Permission.Commands.UpdatePermission
{
    public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdatePermissionCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
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

            RuleFor(x => x.Id).NotEmpty();

        }

        public async Task<bool> BeUniquePermissionName(UpdatePermissionCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return await _context.Permissions
                .Where(x => x.Id != request.Id)
                .AllAsync(l => l.PermissionName != resourcename, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueLocalizationKey(UpdatePermissionCommand request, string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.Permissions.Where(x => x.Id != request.Id).AllAsync(x => x.LocalizationKey != localizationKey, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }
    }
}
