using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.CreateVehicleModel
{
    public class AddVehicleModelCommand  : IRequest<int>
    {
        public string ModelName { get; set; }
        public int VehicleMakeId { get; set; }
       
    }

    public class AddVehicleModelCommandHandler : IRequestHandler<AddVehicleModelCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddVehicleModelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddVehicleModelCommand request, CancellationToken cancellationToken)
        {
            VehicleModel addnew = new VehicleModel
            {
                ModelName = request.ModelName,
                IsActive = true,
                VehicleMakeId = request.VehicleMakeId
            };
            _context.VehicleModels.Add(addnew);
            await _context.SaveChangesAsync(cancellationToken);
            return addnew.Id;
        }
    }
    }
