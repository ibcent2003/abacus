using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.DutyCalculator.Command
{
   public class CreateVehiclePoolCommand : IRequest<VehicleSearchPool>
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public string VehicleTypeName { get; set; }
        public string SpecialFeatureName { get; set; }
        public int SeatingCapacity { get; set; }
        public string EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }
        public int CurrencyId { get; set; }
        public int CountryId { get; set; }

    }
    public class CreateVehiclePoolCommandHandler : IRequestHandler<CreateVehiclePoolCommand, VehicleSearchPool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public CreateVehiclePoolCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<VehicleSearchPool> Handle(CreateVehiclePoolCommand request, CancellationToken cancellationToken)
        {
            var GetMake = _context.VehicleMakes.Where(x => x.Id == request.MakeId).FirstOrDefault();
            var GetModel = _context.VehicleModels.Where(x => x.Id == request.ModelId).FirstOrDefault();
            var GetCurrency = _context.Currencies.Where(x => x.Id == request.CurrencyId).FirstOrDefault();

            var entity = new VehicleSearchPool
            {
                MakeName = GetMake.MakeName,
                ModelName = GetModel.ModelName,
                VehicleTypeName = request.VehicleTypeName,
                SpecialFeatureName = request.SpecialFeatureName,
                EngineCapacity = request.EngineCapacity,
                SeatingCapacity = request.SeatingCapacity,
                FuelType = request.FuelType,
                Year = request.Year,
                UserId = _currentUserService.GetUserId(),
                TransactonDate = DateTime.UtcNow,
                TransactionId = Guid.NewGuid(),
                CurrencyName = GetCurrency.Name,
                CountryId = request.CountryId,
                Status = "Pending"
            };
            _context.VehicleSearchPools.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var vType = await _context.VehicleTypes.Where(x => x.Name == entity.VehicleTypeName).FirstOrDefaultAsync();
            if (vType == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), entity.TransactionId);
            }
            var getHscode = await _context.FreightOverages.Where(x => x.VehicleTypeId == vType.Id).OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
            if (getHscode == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), entity.TransactionId);
            }
            var getAdded = _context.VehicleSearchPools.Where(x => x.TransactionId == entity.TransactionId).FirstOrDefault();
            getAdded.AssessedHSCode = getHscode.HsCode;
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
  }
