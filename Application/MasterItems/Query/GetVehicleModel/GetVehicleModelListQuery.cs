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
using Wbc.Application.Common.Models;
using Wbc.Application.MasterItems.Query.GetVehicleMake;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetVehicleModel
{
   public class GetVehicleModelListQuery : DataTableListRequestModel, IRequest<DataTableVm<VehicleModelDto>>
    {
       // public int MakeId { get; set; }
    }
    public class GetVehicleModelListQueryHandler : IRequestHandler<GetVehicleModelListQuery, DataTableVm<VehicleModelDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleModelListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<VehicleModelDto>> Handle(GetVehicleModelListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.VehicleModels.AsQueryable();
           
            var totalRecords = data.Count();
            if (request.length == -1) request.length = totalRecords;
            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.ModelName.Contains(request.search));

            IQueryable<VehicleModel> OrderingFunction(IQueryable<VehicleModel> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.ModelName) : m.OrderBy(x => x.ModelName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ModelName) : m.OrderByDescending(x => x.ModelName);
            }
            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<VehicleModelDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<VehicleModelDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
              
            };
            return dataTableData;
        }
    }
    }
