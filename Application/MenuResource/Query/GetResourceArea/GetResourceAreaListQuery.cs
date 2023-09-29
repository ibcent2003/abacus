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

namespace Wbc.Application.MenuResource.Query.GetResourceArea
{
    public class GetResourceAreaListQuery : DataTableListRequestModel, IRequest<DataTableVm<ResourceAreaDto>>
    {
    }

    public class GetResourceAreaListQueryHandler : IRequestHandler<GetResourceAreaListQuery, DataTableVm<ResourceAreaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResourceAreaListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<ResourceAreaDto>> Handle(GetResourceAreaListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.ResourceAreas.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.AreaName.Contains(request.search) || x.LocalizationKey.Contains(request.search));

            IQueryable<ResourceArea> OrderingFunction(IQueryable<ResourceArea> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.AreaName) : m.OrderBy(x => x.LocalizationKey) : request.sortColumn == 1 ? m.OrderByDescending(x => x.AreaName) : m.OrderByDescending(x => x.LocalizationKey);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<ResourceAreaDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<ResourceAreaDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
