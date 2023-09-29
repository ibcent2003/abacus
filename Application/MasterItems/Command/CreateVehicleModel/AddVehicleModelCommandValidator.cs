using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Application.MasterItems.Command.CreateVehicleModel
{
   public class AddVehicleModelCommandValidator : AbstractValidator<AddVehicleModelCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddVehicleModelCommandValidator(IApplicationDbContext context, CommonLocalizationService commonLocalizationService)
        {
            _context = context;

            RuleFor(x => x.ModelName).NotEmpty().WithName(commonLocalizationService.Get("VehicleModellbl"))
                .MustAsync(BeUniquePlanName).WithMessage(commonLocalizationService.Get("ErrorBeUniqueVehicleModelRes"));

            RuleFor(x => x.VehicleMakeId).NotEmpty().WithName(commonLocalizationService.Get("VehicleMakelbl"));



        }
        public async Task<bool> BeUniquePlanName(string vmodel, CancellationToken cancellationToken)
        {
            return await _context.VehicleModels
                .AllAsync(l => l.ModelName != vmodel, cancellationToken: cancellationToken);
        }
    }
   
}
