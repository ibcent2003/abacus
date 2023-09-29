using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MenuResource.Commands.CreateTopResource
{
    public class CreateTopResourceCommandValidator : AbstractValidator<CreateTopResourceCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTopResourceCommandValidator(IApplicationDbContext context, CommonLocalizationService localizer)
        {
            _context = context;

            RuleFor(v => v.ResourceName)
                .NotEmpty()
                .WithName(localizer.Get("ResourceNamelbl"))
                .MaximumLength(50)
                .MustAsync(BeUniqueResourceName).WithMessage(localizer.Get("ErrorBeUniqueResourceNameRes"));

            RuleFor(x => x.LocalizationKey)
                .NotEmpty()
                .WithName(localizer.Get("LocalizationKeylbl"))
                .MaximumLength(50)
                .MustAsync(BeUniqueLocalizationKey).WithMessage(localizer.Get("ErrorBeUniqueLocalizationKeyRes"))
                .Must(NotContainSpace).WithMessage(localizer.Get("ErrorNoSpaceInLocalizationKeyRes"));

            RuleFor(x => x.Order).GreaterThan(0).NotEmpty().WithName(localizer.Get("Orderlbl")).MustAsync(BeUniqueOrder).WithMessage(localizer.Get("ErrorBeUniqueOrderRes"));
        }

        public async Task<bool> BeUniqueResourceName(string resourcename, CancellationToken cancellationToken)
        {
            return await _context.TopResources
                .AllAsync(l => l.ResourceName != resourcename, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueLocalizationKey(string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.TopResources.AllAsync(x => x.LocalizationKey != localizationKey, cancellationToken);
        }

        public async Task<bool> BeUniqueOrder(int order, CancellationToken cancellationToken)
        {
            return await _context.TopResources.AllAsync(x => x.Order != order, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }


    }
}
