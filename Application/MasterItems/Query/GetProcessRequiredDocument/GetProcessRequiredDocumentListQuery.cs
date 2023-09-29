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

namespace Wbc.Application.MasterItems.Query.GetProcessRequiredDocument
{
    public class GetProcessRequiredDocumentListQuery : DataTableListRequestModel, IRequest<DataTableVm<SupportingDocumentDto>>
    {
        public int ProcessId { get; set; }
        public int OrganisationId { get; set; }
    }

    public class GetProcessRequiredDocumentListQueryHandler : IRequestHandler<GetProcessRequiredDocumentListQuery, DataTableVm<SupportingDocumentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetProcessRequiredDocumentListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<DataTableVm<SupportingDocumentDto>> Handle(GetProcessRequiredDocumentListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.ProcessRequiredDocuments.Where(x => x.IsActive && x.ProcessId == request.ProcessId).AsQueryable();

            if (!_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                data = data.Where(x => x.SubscriberId == request.OrganisationId);
            }

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.ProcessCode.Contains(request.search));

            IQueryable<Domain.Entities.ProcessRequiredDocument> OrderingFunction(IQueryable<Domain.Entities.ProcessRequiredDocument> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.ProcessCode) : m.OrderBy(x => x.ProcessCode) : request.sortColumn == 1 ? m.OrderByDescending(x => x.ProcessCode) : m.OrderByDescending(x => x.ProcessCode);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<SupportingDocumentDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<SupportingDocumentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
