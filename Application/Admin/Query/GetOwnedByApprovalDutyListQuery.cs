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
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
   public class GetOwnedByApprovalDutyListQuery : DataTableListRequestModel, IRequest<DataTableVm<PendingApprovalDutyDto>>
    {
        public class GetOwnedByApprovalDutyListQueryHandler : IRequestHandler<GetOwnedByApprovalDutyListQuery, DataTableVm<PendingApprovalDutyDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            private readonly ICurrentUserService _currentUserService;


            public GetOwnedByApprovalDutyListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
            {
                _mapper = mapper;
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<DataTableVm<PendingApprovalDutyDto>> Handle(GetOwnedByApprovalDutyListQuery request, CancellationToken cancellationToken)
            {
                var userId = _currentUserService.GetUserId();
                var data = _context.VehicleSearchPools.Where(x => x.OwnedBy == userId && x.Status=="Processing").AsQueryable();
                var totalRecords = data.Count();

                if (request.length == -1) request.length = totalRecords;
                data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.VehicleTypeName.Contains(request.search) || x.MakeName.Contains(request.search));
                IQueryable<VehicleSearchPool> OrderingFunction(IQueryable<VehicleSearchPool> m)
                {
                    return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.MakeName) : m.OrderBy(x => x.MakeName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ModelName) : m.OrderByDescending(x => x.ModelName);
                }
                var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);
                var dataTableData = new DataTableVm<PendingApprovalDutyDto>
                {
                    draw = request.draw,
                    recordsTotal = totalRecords,
                    recordsFiltered = data.Count(),
                    data = await filteredData.ProjectTo<PendingApprovalDutyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
                };

                return dataTableData;
            }
        }
    }
}
