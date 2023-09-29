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

namespace Application.MasterItems.Query.GetHSCodePool
{
    public class GetHSCodePoolListQuery : DataTableListRequestModel, IRequest<DataTableVm<HSCodePoolDto>>
    {
    }

    public class GetHSCodePoolListQueryHandler : IRequestHandler<GetHSCodePoolListQuery, DataTableVm<HSCodePoolDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHSCodePoolListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<HSCodePoolDto>> Handle(GetHSCodePoolListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.HSCodePools.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.HSCode.Contains(request.search) || x.Heading.Contains(request.search));

            IQueryable<HSCodePool> OrderingFunction(IQueryable<HSCodePool> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.HSCode) : m.OrderBy(x => x.Heading) : request.sortColumn == 1 ? m.OrderByDescending(x => x.HSCode) : m.OrderByDescending(x => x.Heading);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<HSCodePoolDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<HSCodePoolDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}

