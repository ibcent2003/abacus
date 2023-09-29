using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MenuResource.Commands.UpdateResource
{
    public class UpdateResourceCommandValidator : AbstractValidator<UpdateResourceCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateResourceCommandValidator(CommonLocalizationService commonLocalizationService, IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.AreaId).NotEmpty().WithName(commonLocalizationService.Get("AreaIdlbl"));
            RuleFor(x => x.PermissionId).NotEmpty().WithName(commonLocalizationService.Get("Permissionlbl"));
            RuleFor(x => x.LocalLizationKey).NotEmpty().WithName(commonLocalizationService.Get("LocalizationKeylbl")).MustAsync(BeUniqueLocalizationKey).WithMessage(commonLocalizationService.Get("ErrorBeUniqueLocalizationKeyRes")).Must(NotContainSpace).WithMessage(commonLocalizationService.Get("ErrorNoSpaceInLocalizationKeyRes"));
            RuleFor(x => x.ResourcePage)
                .NotEmpty()
                .WithName(commonLocalizationService.Get("ResourcePagelbl"))
                .MustAsync(BeUniqueResourceName).WithMessage(commonLocalizationService.Get("ErrorBeUniqueResourceNameRes"));
            RuleFor(x => x.Order).GreaterThan(0).NotEmpty().WithName(commonLocalizationService.Get("Orderlbl")).MustAsync(BeUniqueOrder).WithMessage(commonLocalizationService.Get("ErrorBeUniqueOrderRes"));
        }

        public async Task<bool> BeUniqueResourceName(UpdateResourceCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return await _context.Resources
                .Where(x => x.Id != request.Id)
                .AllAsync(l => l.ResourcePage != resourcename, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueOrder(UpdateResourceCommand request, int order, CancellationToken cancellationToken)
        {
            return await _context.Resources.Where(x => x.Id != request.Id).AnyAsync(x => x.Order != order && x.AreaId != request.AreaId, cancellationToken);
        }

        public async Task<bool> BeUniqueLocalizationKey(UpdateResourceCommand request, string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.Resources.Where(x => x.Id != request.Id).AllAsync(x => x.LocalLizationKey != localizationKey, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }


    }
}
