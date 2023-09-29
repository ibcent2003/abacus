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
using Wbc.Application.Common.Security;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
    [Authorize]
    public class GetAllCalculateDutyListQuery : DataTableListRequestModel, IRequest<DataTableVm<AllCalculateDutyDto>>
    {
        public class GetAllCalculateDutyListQueryHandler : IRequestHandler<GetAllCalculateDutyListQuery, DataTableVm<AllCalculateDutyDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;

            public GetAllCalculateDutyListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
            {
                _mapper = mapper;
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<DataTableVm<AllCalculateDutyDto>> Handle(GetAllCalculateDutyListQuery request, CancellationToken cancellationToken)
            {
                var userId = _currentUserService.GetUserId();
                var data = _context.CalculatedDuties.AsQueryable();

                var totalRecords = data.Count();

                if (request.length == -1) request.length = totalRecords;

                data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.VehicleType.Contains(request.search) || x.VehicleMake.Contains(request.search));

                IQueryable<CalculatedDuty> OrderingFunction(IQueryable<CalculatedDuty> m)
                {
                    return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.VehicleMake) : m.OrderBy(x => x.VehicleModel) : request.sortColumn == 1 ? m.OrderByDescending(x => x.VehicleModel) : m.OrderByDescending(x => x.VehicleModel);
                }
                var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);
                var dataTableData = new DataTableVm<AllCalculateDutyDto>
                {
                    draw = request.draw,
                    recordsTotal = totalRecords,
                    recordsFiltered = data.Count(),
                    data = await filteredData.ProjectTo<AllCalculateDutyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
                };

                return dataTableData;
            }
        }
     }
}
