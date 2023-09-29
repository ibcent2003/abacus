using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MenuResource.Commands.UpdateTopResource
{
    public class UpdateTopResourceCommandValidator : AbstractValidator<UpdateTopResourceCommand>
    {

        private readonly IApplicationDbContext _context;

        public UpdateTopResourceCommandValidator(IApplicationDbContext context, CommonLocalizationService localizer)
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

            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Order).GreaterThan(0).NotEmpty().WithName(localizer.Get("Orderlbl")).MustAsync(BeUniqueOrder).WithMessage(localizer.Get("ErrorBeUniqueOrderRes"));
        }

        public async Task<bool> BeUniqueResourceName(UpdateTopResourceCommand command, string resourceName, CancellationToken cancellationToken)
        {
            return await _context.TopResources
                .Where(x => x.Id != command.Id)
                .AllAsync(l => l.ResourceName != resourceName, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueLocalizationKey(UpdateTopResourceCommand command, string localizationKey, CancellationToken cancellationToken)
        {
            return await _context.TopResources.Where(x => x.Id != command.Id).AllAsync(x => x.LocalizationKey != localizationKey, cancellationToken);
        }

        public async Task<bool> BeUniqueOrder(UpdateTopResourceCommand request, int order, CancellationToken cancellationToken)
        {
            return await _context.TopResources.Where(x => x.Id != request.Id).AllAsync(x => x.Order != order, cancellationToken);
        }

        public bool NotContainSpace(string localizationKey)
        {
            return localizationKey.NotContainsSpace();
        }
    }
}
