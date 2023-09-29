using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.GeneralGoods.Command.CreateGeneralGoodsSearch;
using Wbc.Application.Resources;

namespace Wbc.Application.GeneralGoods.Command.CreateGeneralGoodsSearch
{
  public  class CreateGeneralGoodsSearchCommandValidator : AbstractValidator<CreateGeneralGoodsSearchCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGeneralGoodsSearchCommandValidator(CommonLocalizationService localizationService, IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.ExportingCountryId).NotEmpty().WithName(localizationService.Get("ExportingCountrylbl"));                
            RuleFor(x => x.CountryId).NotEmpty().WithName(localizationService.Get("ImportingCountrylbl"));
            RuleFor(x => x.CurrencyId).NotEmpty().WithName(localizationService.Get("CurrencyNamelbl"));
            RuleFor(x => x.HsCode).NotEmpty().WithName(localizationService.Get("HsCdelbl"));
            RuleFor(x => x.FOB).NotEmpty().WithName(localizationService.Get("Foblbl"));

        }

    }
}
