using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.UpdateVehicleMake
{
    public class UpdateVehicleMakeCommand : IRequest, IMapFrom<VehicleMake>
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public bool IsActive { get; set; }

    }

    public class UpdateVehicleMakeCommandHandler : IRequestHandler<UpdateVehicleMakeCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateVehicleMakeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateVehicleMakeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleMakes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleMake), request.Id);
            }
            entity.MakeName = request.MakeName;
            entity.IsActive = request.IsActive;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
