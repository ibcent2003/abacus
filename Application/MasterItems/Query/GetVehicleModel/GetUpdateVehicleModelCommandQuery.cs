﻿using AutoMapper;
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
using Wbc.Application.MasterItems.Command.UpdateVehicleModel;
using Wbc.Application.MasterItems.Query.GetVehicleMake;

namespace Wbc.Application.MasterItems.Query.GetVehicleModel
{
    public class GetUpdateVehicleModelCommandQuery : IRequest<VehicleModelVm>
    {
        public int Id { get; set; }
     
    }
    public class GetUpdateVehicleModelCommandQueryHandler : IRequestHandler<GetUpdateVehicleModelCommandQuery, VehicleModelVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateVehicleModelCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehicleModelVm> Handle(GetUpdateVehicleModelCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleModels.FindAsync(request.Id);
            return new VehicleModelVm
            {
                UpdateCommand = _mapper.Map<UpdateVehicleModelCommand>(entity),
      
                VehicleMakeList = await _context.VehicleMakes.Where(x => x.IsActive).ProjectTo<VehicleMakeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
               

            };
        }
    }
    }
