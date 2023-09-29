using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.UpdateCountry
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCountryCommandValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;
            RuleFor(x => x.CountryName).NotEmpty().WithName(localizationService.Get("CountryNamelbl"));               
            RuleFor(x => x.CountryCode).NotEmpty().WithName(localizationService.Get("CountryCodelbl"));
            RuleFor(x => x.CurrencyName).NotEmpty().WithName(localizationService.Get("CurrencyNamelbl"));
            RuleFor(x => x.CurrencyCode).NotEmpty().WithName(localizationService.Get("CurrencyCodelbl"));
        }
       
    }
}
