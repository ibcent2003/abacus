using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.MasterItems.Query.GetSubscriptionType;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionType
{
    public class GetSubscriptionTypeListQuery : DataTableListRequestModel, IRequest<DataTableVm<SubscriptionTypeDto>>
    {

    }

    public class GetSubscriptionTypeListQueryHandler : IRequestHandler<GetSubscriptionTypeListQuery, DataTableVm<SubscriptionTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionTypeListQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DataTableVm<SubscriptionTypeDto>> Handle(GetSubscriptionTypeListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.SubscriptionTypes.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.Name.Contains(request.search) || x.Description.Contains(request.search));

            IQueryable<Domain.Entities.SubscriptionType> OrderingFunction(IQueryable<Domain.Entities.SubscriptionType> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.Name) : m.OrderBy(x => x.Description) : request.sortColumn == 1 ? m.OrderByDescending(x => x.Name) : m.OrderByDescending(x => x.Description);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<SubscriptionTypeDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<SubscriptionTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }

    }
