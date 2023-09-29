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
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Command.UpdatePendingDuty
{
    public class UpdatePendingDutyToCalculatedCommand : IRequest, IMapFrom<VehicleSearchPool>
    {
        public Guid TransactionId { get; set; }
        public decimal HDV { get; set; }
        public string Hscode { get; set; }
        public string Chassis { get; set; }
        public int NoOfDoor { get; set; }
    }

    public class UpdatePendingDutyToCalculatedCommandHandler : IRequestHandler<UpdatePendingDutyToCalculatedCommand>
    {

        private readonly IApplicationDbContext _context;
        private readonly IDutyCalculatorService _dutyCalculatorService;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePendingDutyToCalculatedCommandHandler(IApplicationDbContext context, IDutyCalculatorService dutyCalculatorService, ICurrentUserService currentUserService)
        {
            _context = context;
            _dutyCalculatorService = dutyCalculatorService;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdatePendingDutyToCalculatedCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleSearchPools.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }
            var vType = await _context.VehicleTypes.Where(x => x.Name == entity.VehicleTypeName).FirstOrDefaultAsync();
            if (vType == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }

          
            DateTime now = DateTime.Now;
            string str1 = "First";
            if (now.Month > 6)
            {
                str1 = "Second";
            }

            int year = now.Year - entity.Year;
            var getHscode = await _context.FreightOverages.Where(x => x.VehicleTypeId == vType.Id && (int?)year >= x.MinimumAge && (int?)year <= x.MaximumAge).FirstOrDefaultAsync();
            if (getHscode == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }

            entity.CalculatedBy = _currentUserService.GetUserId();
            entity.CalculatedDate = DateTime.UtcNow;
            entity.NoOfDoor = request.NoOfDoor;
            entity.HDV = request.HDV;
            entity.AssessedHSCode = request.Hscode;
            entity.ChassisNo = request.Chassis;
            await _context.SaveChangesAsync(cancellationToken);
            //do calculation         

            var duty = await _dutyCalculatorService.GhanaCalculateFromPool(entity, cancellationToken);
            if (duty != null)
            {
              
                return Unit.Value;
            }
            return Unit.Value;
           
        }
    }
 }
