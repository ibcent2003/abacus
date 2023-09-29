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

namespace Wbc.Application.MenuResource.Query.GetTopResource
{
    public class GetTopResourceListQuery : DataTableListRequestModel, IRequest<DataTableVm<TopResourceDto>>
    {

    }

    public class GetTopResourceListQueryHandler : IRequestHandler<GetTopResourceListQuery, DataTableVm<TopResourceDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetTopResourceListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<TopResourceDto>> Handle(GetTopResourceListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.TopResources.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.ResourceName.Contains(request.search) || x.LocalizationKey.Contains(request.search));

            IQueryable<TopResource> OrderingFunction(IQueryable<TopResource> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.ResourceName) : m.OrderBy(x => x.LocalizationKey) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ResourceName) : m.OrderByDescending(x => x.LocalizationKey);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<TopResourceDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<TopResourceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;


        }

    }

}
