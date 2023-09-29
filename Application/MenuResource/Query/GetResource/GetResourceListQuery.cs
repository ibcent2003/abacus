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

namespace Wbc.Application.MenuResource.Query.GetResource
{
    public class GetResourceListQuery : DataTableListRequestModel, IRequest<DataTableVm<ResourceDto>>
    {

    }

    public class GetResourceListQueryHandler : IRequestHandler<GetResourceListQuery, DataTableVm<ResourceDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResourceListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<ResourceDto>> Handle(GetResourceListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Resources.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.ResourcePage.Contains(request.search) || x.LocalLizationKey.Contains(request.search));

            IQueryable<Resource> OrderingFunction(IQueryable<Resource> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.ResourcePage) : m.OrderBy(x => x.LocalLizationKey) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ResourcePage) : m.OrderByDescending(x => x.LocalLizationKey);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<ResourceDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<ResourceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
