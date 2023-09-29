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

namespace Wbc.Application.MasterItems.Query.GetRequiredDocument
{
    public class GetRequiredDocumentListQuery : DataTableListRequestModel, IRequest<DataTableVm<RequiredDocumentDto>>
    {
    }
    public class GetRequiredDocumentListQueryHandler : IRequestHandler<GetRequiredDocumentListQuery, DataTableVm<RequiredDocumentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetRequiredDocumentListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<DataTableVm<RequiredDocumentDto>> Handle(GetRequiredDocumentListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.RequiredDocuments.Where(x => x.IsActive).AsQueryable();

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                data = data.Where(x => x.SubscriberId == null);
            }
            else
            {
                var orgId = _currentUserService.GetUserOrganisationId();

                var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

                data = data.Where(x => x.SubscriberId == subscriber.Id && !x.IsInternalUse);
            }

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.DocumentName.Contains(request.search) || x.DocumentDescription.Contains(request.search));

            IQueryable<Domain.Entities.RequiredDocument> OrderingFunction(IQueryable<Domain.Entities.RequiredDocument> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.DocumentName) : m.OrderBy(x => x.DocumentDescription) : request.sortColumn == 1 ? m.OrderByDescending(x => x.DocumentName) : m.OrderByDescending(x => x.DocumentDescription);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<RequiredDocumentDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<RequiredDocumentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
