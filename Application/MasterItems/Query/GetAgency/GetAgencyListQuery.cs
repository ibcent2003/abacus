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

namespace Application.MasterItems.Query.GetAgency
{
   public class GetAgencyListQuery : DataTableListRequestModel, IRequest<DataTableVm<AgencyDto>>
    {
    }

    public class GetAgencyListQueryHandler : IRequestHandler<GetAgencyListQuery, DataTableVm<AgencyDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAgencyListQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<DataTableVm<AgencyDto>> Handle(GetAgencyListQuery request, CancellationToken cancellationToken)
        {

            var data = _context.Agencies.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.AgencyName.Contains(request.search) || x.AgencyCode.Contains(request.search));

            IQueryable<Agency> OrderingFunction(IQueryable<Agency> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.AgencyName) : m.OrderBy(x => x.AgencyCode) : request.sortColumn == 1 ? m.OrderByDescending(x => x.AgencyName) : m.OrderByDescending(x => x.AgencyCode);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<AgencyDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<AgencyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
