using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.MasterItems.Query.GetProcess
{
    public class GetProcessListQuery : DataTableListRequestModel, IRequest<DataTableVm<ProcessDto>>
    {
    }

    public class GetProcessListQueryHandler : IRequestHandler<GetProcessListQuery, DataTableVm<ProcessDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetProcessListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<DataTableVm<ProcessDto>> Handle(GetProcessListQuery request, CancellationToken cancellationToken)
        {

            var data = _context.Processes.Where(x => x.IsActive).AsQueryable();

            if (!_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                data = data.Where(x => !x.IsInternal);
            }

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.ProcessName.Contains(request.search) || x.ProcessCode.Contains(request.search));

            IQueryable<Domain.Entities.Process> OrderingFunction(IQueryable<Domain.Entities.Process> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.ProcessName) : m.OrderBy(x => x.ProcessCode) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ProcessName) : m.OrderByDescending(x => x.ProcessCode);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<ProcessDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<ProcessDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
