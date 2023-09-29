using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.UpdateVehicleMake;

namespace Wbc.Application.MasterItems.Query.GetVehicleMake
{
  public class GetUpdateVehicleMakeCommandQuery : IRequest<UpdateVehicleMakeCommand>
    {
        public int Id { get; set; }
    }

    public class GetUpdateVehicleMakeCommandQueryHandler : IRequestHandler<GetUpdateVehicleMakeCommandQuery, UpdateVehicleMakeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateVehicleMakeCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

            
        public async Task<UpdateVehicleMakeCommand> Handle(GetUpdateVehicleMakeCommandQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.VehicleMakes.FindAsync(request.Id);

            return _mapper.Map<UpdateVehicleMakeCommand>(entity);
        }
    }
}
