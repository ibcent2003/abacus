using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class GetSubscriptionPendingApprovalQuery : DataTableListRequestModel, IRequest<DataTableVm<SubscriptionDto>>
    {
    }

    public class GetSubscriptionPendingApprovalQueryHandler : IRequestHandler<GetSubscriptionPendingApprovalQuery, DataTableVm<SubscriptionDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionPendingApprovalQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<SubscriptionDto>> Handle(GetSubscriptionPendingApprovalQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Subscribers.AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.EntityName.Contains(request.search) || x.EmailAddress.Contains(request.search));

            IQueryable<Domain.Entities.Subscriber> OrderingFunction(IQueryable<Domain.Entities.Subscriber> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.EntityName) : m.OrderBy(x => x.CountryCode) : request.sortColumn == 1 ? m.OrderByDescending(x => x.EntityName) : m.OrderByDescending(x => x.CountryCode);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<SubscriptionDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<SubscriptionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
