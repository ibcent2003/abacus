using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Workflow.Query.GetPendingApproval
{
    public class GetPendingApprovalQuery : DataTableListRequestModel, IRequest<DataTableVm<InboxDto>>
    {

    }

    public class GetPendingApprovalQueryHandler : IRequestHandler<GetPendingApprovalQuery, DataTableVm<InboxDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetPendingApprovalQueryHandler(IApplicationDbContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DataTableVm<InboxDto>> Handle(GetPendingApprovalQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();

            var processIds = _dbContext.WorkflowInboxes.Where(x => x.IdentityId.Equals(userId)).Select(x => x.ProcessId);

            var data = _dbContext.Documents.Where(x => processIds.Contains(x.WorkflowProcessId)).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.ProcessName.Contains(request.search) || x.StateName.Contains(request.search));

            IQueryable<Domain.Entities.Document> OrderingFunction(IQueryable<Domain.Entities.Document> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.ProcessName) : m.OrderBy(x => x.StateName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ProcessName) : m.OrderByDescending(x => x.StateName);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<InboxDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<InboxDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
