using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.Admin.Command.UpdatePendingDuty
{
    public class UpdatePendingDutyToCalculateValidator : AbstractValidator<UpdatePendingDutyToCalculatedCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdatePendingDutyToCalculateValidator(IApplicationDbContext context, CommonLocalizationService localizationService)
        {
            _context = context;
            RuleFor(x => x.HDV).NotEmpty().WithName(localizationService.Get("HDVlbl")).WithMessage(localizationService.Get("ErrorHDV"));
            RuleFor(x => x.Chassis).NotEmpty().WithName(localizationService.Get("Chassislbl")).WithMessage(localizationService.Get("ErrorChassis"));
            RuleFor(x => x.Hscode).NotEmpty().WithName(localizationService.Get("Hscodelbl")).WithMessage(localizationService.Get("Errorhscode"));
            RuleFor(x => x.NoOfDoor).NotEmpty().WithName(localizationService.Get("NoOfDoorlbl")).WithMessage(localizationService.Get("ErrorNoOfDoor"));

        }
    }
}
