using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.CreateHSCodePool
{
   public class AddHscodePoolCommandValidator : AbstractValidator<AddHscodePoolCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddHscodePoolCommandValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService)
        {
            _context = context;

            RuleFor(x => x.Description).NotEmpty().WithName(commonLocalizationService.Get("Descriptionlbl"));
            RuleFor(x => x.CountryId).NotEmpty().WithName(commonLocalizationService.Get("CountryIdlbl"));
            RuleFor(x => x.StandardUnitOfQuantity).NotEmpty().WithName(commonLocalizationService.Get("StandardUnitOfQuantitylbl"));
            RuleFor(x => x.Heading).NotEmpty().WithName(commonLocalizationService.Get("Headinglbl")).MustAsync(BeUniqueHeader).WithMessage(commonLocalizationService.Get("ErrorBeUniqueHeaderRes"));
            RuleFor(x => x.HSCode).NotEmpty().WithName(commonLocalizationService.Get("HSCodelbl")).MustAsync(BeUniqueHSCode).WithMessage(commonLocalizationService.Get("ErrorBeUniqueHSCodeRes")).Must(NotContainSpace).WithMessage(commonLocalizationService.Get("ErrorNoSpaceInHSCodeRes"));
        }

        public async Task<bool> BeUniqueHeader(string heading, CancellationToken cancellationToken)
        {
            return await _context.HSCodePools.AllAsync(x => x.Heading != heading, cancellationToken);
        }

        public async Task<bool> BeUniqueHSCode(string hscode, CancellationToken cancellationToken)
        {
            return await _context.HSCodePools.AllAsync(x => x.HSCode != hscode, cancellationToken);
        }

        public bool NotContainSpace(string hscode)
        {
            return hscode.NotContainsSpace();
        }
    }
}
