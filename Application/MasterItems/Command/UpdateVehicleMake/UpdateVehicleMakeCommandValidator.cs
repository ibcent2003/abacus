using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.UpdateVehicleMake
{
  public class UpdateVehicleMakeCommandValidator : AbstractValidator<UpdateVehicleMakeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehicleMakeCommandValidator(IApplicationDbContext context, CommonLocalizationService localizer)
        {
            _context = context;
            RuleFor(v => v.MakeName).NotEmpty().WithName(localizer.Get("VehicleMakeNamelbl"));                         
        }

      
    }
}
