using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Resources;

namespace Wbc.Application.MasterItems.Command.CreateVehicleMake
{
   public class AddVehicleMakeCommadValidator : AbstractValidator<AddVehicleMakeCommad>
    {
        private readonly IApplicationDbContext _context;
        public AddVehicleMakeCommadValidator(CommonLocalizationService localizationService, IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x=>x.MakeName).NotEmpty().WithName(localizationService.Get("VehicleMakeNamelbl")).MaximumLength(100).MustAsync(BeUniqueVehicleName).WithMessage(localizationService.Get("ErrorBeUniqueVehicleNameError"));
        }

        public async Task<bool> BeUniqueVehicleName(string name, CancellationToken cancellationToken)
        {
            return await _context.VehicleMakes
                .AllAsync(x =>x.MakeName != name, cancellationToken: cancellationToken);
        }
    }
}
