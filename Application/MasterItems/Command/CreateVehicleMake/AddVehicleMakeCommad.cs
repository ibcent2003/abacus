using FluentValidation.Validators;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.MasterItems.Command.CreateVehicleMake
{
  public  class AddVehicleMakeCommad : IRequest<int>
  {
            public string MakeName { get; set; }
      
    }

    public class AddVehicleMakeCommadHandler : IRequestHandler<AddVehicleMakeCommad, int>
    {
        private readonly IApplicationDbContext _context;

        public AddVehicleMakeCommadHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddVehicleMakeCommad request, CancellationToken cancellationToken)
        {
             Domain.Entities.VehicleMake addnew = new Domain.Entities.VehicleMake
            {
                MakeName = request.MakeName,
                IsActive  = true
                
            };
            _context.VehicleMakes.Add(addnew);
            await _context.SaveChangesAsync(cancellationToken);
            return addnew.Id;
        }
    }
}
