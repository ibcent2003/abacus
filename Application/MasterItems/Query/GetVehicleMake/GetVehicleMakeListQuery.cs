using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetVehicleMake
{
    public  class GetVehicleMakeListQuery : DataTableListRequestModel, IRequest<DataTableVm<VehicleMakeDto>>
    {
    }

    public class GetVehicleListQueryHandle :  IRequestHandler<GetVehicleMakeListQuery, DataTableVm<VehicleMakeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleListQueryHandle(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<DataTableVm<VehicleMakeDto>> Handle(GetVehicleMakeListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.VehicleMakes.AsQueryable();
         

            var totalRecords = data.Count();           
            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.MakeName.Contains(request.search));

            IQueryable<VehicleMake> OrderingFunction(IQueryable<VehicleMake> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.MakeName) : m.OrderBy(x => x.MakeName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.MakeName) : m.OrderByDescending(x => x.MakeName);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<VehicleMakeDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<VehicleMakeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}

