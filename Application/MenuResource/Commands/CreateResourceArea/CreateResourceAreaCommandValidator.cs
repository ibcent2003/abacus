using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MenuResource.Commands.CreateResourceArea
{
    public class CreateResourceAreaCommandValidator : AbstractValidator<CreateResourceAreaCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateResourceAreaCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.ParentId).NotEmpty().WithName(localizationService.Get("ResourceHeaderlbl"));
            RuleFor(x => x.LocalizationKey).NotEmpty().WithName(localizationService.Get("LocalizationKeylbl"))
                .Must(NotContainSpace).WithMessage(localizationService.Get("ErrorNoSpaceInLocalizationKeyRes"))
                .MustAsync(BeUniqueLocalizationKey)
                .WithMessage(localizationService.Get("ErrorBeUniqueLocalizationKeyRes"));
            RuleFor(x => x.AreaName).NotEmpty().WithName(localizationService.Get("AreaIdlbl")).Must(NotContainSpace)
                .WithMessage(localizationService.Get("ErrorNoSpaceInLocalizationKeyRes"))
                .MustAsync(BeUniqueResourceName)
                .WithMessage(localizationService.Get("ErrorBeUniqueAreaName"));
            RuleFor(x => x.IconUrl).NotEmpty().WithName(localizationService.Get("IconUrllbl"))
                .MustAsync(BeUniqueIconUrl).WithMessage(localizationService.Get("ErrorBeUniqueIconUrl"));

            RuleFor(x => x.Order).GreaterThan(0).NotEmpty().WithName(localizationService.Get("Orderlbl"));
        }

        public async Task<bool> BeUniqueLocalizationKey(string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.AllAsync(x => x.LocalizationKey != localizationKey, cancellationToken);
        }

    
        public async Task<bool> BeUniqueResourceName(string resourcename, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.AllAsync(l => l.AreaName != resourcename, cancellationToken);
        }

        public async Task<bool> BeUniqueIconUrl(string url, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.AllAsync(l => l.IconUrl != url, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }
    }
}