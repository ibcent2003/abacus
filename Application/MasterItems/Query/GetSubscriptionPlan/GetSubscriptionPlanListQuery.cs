using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionPlan
{
   public class GetSubscriptionPlanListQuery :   DataTableListRequestModel, IRequest<DataTableVm<SubscriptionPlanDto>>
    {
    }
    public class GetSubscriptionPlanListQueryHandler : IRequestHandler<GetSubscriptionPlanListQuery, DataTableVm<SubscriptionPlanDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionPlanListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataTableVm<SubscriptionPlanDto>> Handle(GetSubscriptionPlanListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.SubscriptionPlans.Where(x => x.IsActive).AsQueryable();
            var totalRecords = data.Count();
            if (request.length == -1) request.length = totalRecords;
            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.PlanName.Contains(request.search));

            IQueryable<Domain.Entities.SubscriptionPlan> OrderingFunction(IQueryable<Domain.Entities.SubscriptionPlan> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.PlanName) : m.OrderBy(x => x.NoOfUse) : request.sortColumn == 1 ? m.OrderByDescending(x => x.PlanName) : m.OrderByDescending(x => x.NoOfUse);
            }
            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<SubscriptionPlanDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<SubscriptionPlanDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
    }
