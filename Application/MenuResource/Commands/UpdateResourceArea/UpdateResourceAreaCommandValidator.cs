using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MenuResource.Commands.UpdateResourceArea
{
    public class UpdateResourceAreaCommandValidator : AbstractValidator<UpdateResourceAreaCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateResourceAreaCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;

            RuleFor(x => x.ParentId).NotEmpty().WithName(localizationService.Get("ResourceHeaderlbl"));
            RuleFor(x => x.LocalizationKey).NotEmpty().WithName(localizationService.Get("LocalizationKeylbl")).Must(NotContainSpace).WithMessage(localizationService.Get("ErrorNoSpaceInLocalizationKeyRes")).MustAsync(BeUniqueLocalizationKey).WithMessage(localizationService.Get("ErrorBeUniqueLocalizationKeyRes"));
            RuleFor(x => x.AreaName)
                .NotEmpty()
                .WithName(localizationService.Get("AreaIdlbl"))
                .Must(NotContainSpace)
                .WithMessage(localizationService.Get("ErrorNoSpaceInLocalizationKeyRes"))
                .MustAsync(BeUniqueResourceName)
                .WithMessage(localizationService.Get("ErrorBeUniqueAreaName"));
            RuleFor(x => x.IconUrl).NotEmpty().WithName(localizationService.Get("IconUrllbl")).MustAsync(BeUniqueIconUrl).WithMessage(localizationService.Get("ErrorBeUniqueIconUrl"));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Order).GreaterThan(0).NotEmpty().WithName(localizationService.Get("Orderlbl")).MustAsync(BeUniqueOrder).WithMessage(localizationService.Get("ErrorBeUniqueOrderRes"));
        }

        public async Task<bool> BeUniqueLocalizationKey(UpdateResourceAreaCommand request, string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.Where(x => x.Id != request.Id).AllAsync(x => x.LocalizationKey != localizationKey, cancellationToken);
        }

        public async Task<bool> BeUniqueResourceName(UpdateResourceAreaCommand request, string resourcename, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.Where(x => x.Id != request.Id).AllAsync(l => l.AreaName != resourcename, cancellationToken);
        }

        public async Task<bool> BeUniqueOrder(UpdateResourceAreaCommand request, int order, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.Where(x => x.Id != request.Id).AnyAsync(x => x.Order != order && x.Order != request.Order, cancellationToken);
        }

        public async Task<bool> BeUniqueIconUrl(UpdateResourceAreaCommand request, string url, CancellationToken cancellationToken)
        {
            return await _context.ResourceAreas.Where(x => x.Id != request.Id).AllAsync(l => l.IconUrl != url, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }
    }
}
