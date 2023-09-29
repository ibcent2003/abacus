using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.DutyCalculator.Command
{
    public class CreateSearchCommand : IRequest<CalculatedDuty>, IMapFrom<VehicleFactory>
    {
        public string chassis { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string Year { get; set; }
        public string VehicleTypeName { get; set; }
        public string Features { get; set; }
        public int SeatingCapacity { get; set; }
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }
       // public string HDV { get; set; }
        public int CurrencyId { get; set; }
        public int CountryId { get; set; }
    }
    public class CreateSearchCommandHandler : IRequestHandler<CreateSearchCommand, CalculatedDuty>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDutyCalculatorService _dutycalculatorService;
        private readonly IMediator _mediator;

        public CreateSearchCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDutyCalculatorService dutycalculatorService, IMediator mediator)
        {
            _context = context;
            _currentUserService = currentUserService;
            _dutycalculatorService = dutycalculatorService;
            _mediator = mediator;
        }

        public async Task<CalculatedDuty> Handle(CreateSearchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.chassis != null)
                {
                    var getvehcile = await _context.VehicleFactories.Where(x => x.ChassisNo == request.chassis).FirstOrDefaultAsync();
                    if (getvehcile != null)
                    {
                        if (request.CountryId == 1)
                        {
                            var duty = await _dutycalculatorService.GhanaCalculation(getvehcile, cancellationToken);
                            return duty;
                        }
                        //else do other countries ---- But return null for now.
                        return null;
                    }
                    //this where you call nada. Create a handler to return search not found.
                    return null;
                }
                else
                {
                    var GetMake = _context.VehicleMakes.Where(x => x.Id == request.MakeId).FirstOrDefault();
                    var GetModel = _context.VehicleModels.Where(x => x.Id == request.ModelId).FirstOrDefault();
                    var GetCurrency = _context.Currencies.Where(x => x.Id == request.CurrencyId).FirstOrDefault();
                    var getvehcile = await _context.VehicleFactories.Where(x => x.MakeName == GetMake.MakeName && x.ModelName == GetModel.ModelName && x.ManufactureYear == request.Year && x.VehicleType==request.VehicleTypeName && x.SpecialFeatures==request.Features && x.EngineCapacity==request.EngineCapacity && x.FuelType==request.FuelType && x.SeatingCapacity==request.SeatingCapacity && x.Currency== GetCurrency.Name).FirstOrDefaultAsync();
                    if (getvehcile != null)
                    {
                       
                        //check if country is ghana
                        if (request.CountryId == 1)
                        {
                            //only if country is Ghana
                            var duty = await _dutycalculatorService.GhanaCalculation(getvehcile, cancellationToken);
                            return duty;
                        }

                        //else do other countries ---- But return null for now.
                        return null;
                    }
                    else
                    {
                        //this where you call nada. Create a handler to return search not found.
                      ///  var StoreSearch = await _mediator.Send(new CreateVehiclePoolCommand { MakeName = GetMake.MakeName, ModelName = GetModel.ModelName, VehicleTypeName = request.VehicleTypeName, SpecialFeatureName = request.Features, EngineCapacity = request.EngineCapacity, SeatingCapacity = request.SeatingCapacity, FuelType = request.FuelType, Year = int.Parse(request.Year.ToString()) });                        
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
    }

}
