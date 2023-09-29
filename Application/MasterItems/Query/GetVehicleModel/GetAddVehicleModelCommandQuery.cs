using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Query.GetVehicleMake;

namespace Wbc.Application.MasterItems.Query.GetVehicleModel
{
   public class GetAddVehicleModelCommandQuery : IRequest<VehicleModelVm>
    {
    }
    public class GetAddVehicleModelCommandQueryHandler : IRequestHandler<GetAddVehicleModelCommandQuery, VehicleModelVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddVehicleModelCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehicleModelVm> Handle(GetAddVehicleModelCommandQuery request, CancellationToken cancellationToken)
        {
            return new VehicleModelVm
            {
             
                VehicleMakeList = await _context.VehicleMakes.Where(x => x.IsActive).ProjectTo<VehicleMakeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
            };
        }
    }
}
