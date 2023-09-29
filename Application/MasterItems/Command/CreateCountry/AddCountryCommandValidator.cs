using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.CreateCountry;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Commands.CreateCountry
{
    public class AddCountryCommandValidator : AbstractValidator<AddCountryCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddCountryCommandValidator(CommonLocalizationService localizationService, IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.CountryName).NotEmpty().WithName(localizationService.Get("CountryNamelbl"))
                .MustAsync(BeUniqueCountryName).WithMessage(localizationService.Get("ErrorBeUniqueCountryName"));

            RuleFor(x => x.CountryCode).NotEmpty().WithName(localizationService.Get("CountryCodelbl"));

            RuleFor(x => x.CurrencyName).NotEmpty().WithName(localizationService.Get("CurrencyNamelbl"));
            RuleFor(x => x.CurrencyCode).NotEmpty().WithName(localizationService.Get("CurrencyCodelbl"));
          
        }

        public async Task<bool> BeUniqueCountryName(string name, CancellationToken cancellationToken)
        {
            return await _context.Countries
                .AllAsync(l => l.CountryName != name, cancellationToken: cancellationToken);
        }

    }
}
