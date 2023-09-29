using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.UpdateVehicleModel
{
   public class UpdateVehicleModelCommand : IRequest, IMapFrom<VehicleModel>
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int VehicleMakeId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateVehicleModelCommandHandler : IRequestHandler<UpdateVehicleModelCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateVehicleModelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVehicleModelCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleModels.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleModel), request.Id);
            }

            entity.ModelName = request.ModelName;
            entity.VehicleMakeId = request.VehicleMakeId;           
            entity.IsActive = request.IsActive;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
    }
