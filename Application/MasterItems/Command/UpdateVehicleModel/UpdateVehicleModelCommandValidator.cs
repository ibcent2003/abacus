
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.UpdateVehicleModel
{
   public class UpdateVehicleModelCommandValidator : AbstractValidator<UpdateVehicleModelCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehicleModelCommandValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService)
        {
            _context = context;
            RuleFor(x => x.ModelName).NotEmpty().WithName(commonLocalizationService.Get("VehicleModellbl"));              
            RuleFor(x => x.VehicleMakeId).NotEmpty().WithName(commonLocalizationService.Get("VehicleMakeIdlbl"));

        }
      
    }
}
