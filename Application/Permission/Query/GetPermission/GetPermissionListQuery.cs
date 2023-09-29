using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class GetPermissionListQuery : DataTableListRequestModel, IRequest<DataTableVm<PermissionDto>>
    {
    }

    public class GetPermissionListQueryHandler : IRequestHandler<GetPermissionListQuery, DataTableVm<PermissionDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPermissionListQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DataTableVm<PermissionDto>> Handle(GetPermissionListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Permissions.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.PermissionName.Contains(request.search) || x.LocalizationKey.Contains(request.search));

            IQueryable<Domain.Entities.Permission> OrderingFunction(IQueryable<Domain.Entities.Permission> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.PermissionName) : m.OrderBy(x => x.PersmissionDescription) : request.sortColumn == 1 ? m.OrderByDescending(x => x.PermissionName) : m.OrderByDescending(x => x.PersmissionDescription);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<PermissionDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<PermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
