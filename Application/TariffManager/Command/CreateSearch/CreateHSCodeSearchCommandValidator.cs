using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.TariffManager.Command.CreateSearch
{
   public class CreateHSCodeSearchCommandValidator : AbstractValidator<CreateHSCodeSearchCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly CommonLocalizationService _localizationService;

        public CreateHSCodeSearchCommandValidator(CommonLocalizationService localizationService, IApplicationDbContext context)
        {
            _context = context;
            _localizationService = localizationService;
            RuleFor(x => x.CountryId).NotEmpty().WithName(localizationService.Get("CountryNamelbl"));               
            RuleFor(x => x.HScode).NotEmpty().WithName(localizationService.Get("HSCodelbl"));        

        }
    }
}
