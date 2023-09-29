using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Admin.Command.CreateCalculatedDuty
{
    public class AddNewVehicleToFactoryCommand : IRequest<int>
    {
        #region calcalated values
        public Guid TransactionId { get; set; }
      

        #endregion
    }

    public class AddNewCalculatedDutyCommandHandler : IRequestHandler<AddNewVehicleToFactoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddNewCalculatedDutyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddNewVehicleToFactoryCommand request, CancellationToken cancellationToken)
        {
            var GetNewVehicle = await _context.CalculatedDuties.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();
           
            var entity = new Domain.Entities.VehicleFactory
            {
                VehicleType = GetNewVehicle.VehicleType,
                ChassisNo = GetNewVehicle.ChassisNo,
                MakeName = GetNewVehicle.VehicleMake,
                ModelName = GetNewVehicle.VehicleModel,
                ManufactureYear = GetNewVehicle.YearOfManufacture,
                HDV = GetNewVehicle.HDV,
                EngineCapacity = GetNewVehicle.CC,
                AssessedHSCode = GetNewVehicle.HsCode,
                Condition = "Used",
                FuelType = GetNewVehicle.FuelType,
                NoOfDoors = GetNewVehicle.NoOfDoors,
                SeatingCapacity = GetNewVehicle.SeatingCapacity,
                SpecialFeatures = GetNewVehicle.SpecialFeatures,
                Colour = "Black",
                Currency = GetNewVehicle.CurrencyName

            };
            _context.VehicleFactories.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
 }
