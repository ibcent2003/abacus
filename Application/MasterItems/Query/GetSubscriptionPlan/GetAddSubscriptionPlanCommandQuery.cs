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
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Application.MasterItems.Query.GetSubscriptionType;

namespace Application.MasterItems.Query.GetSubscriptionPlan
{
   public class GetAddSubscriptionPlanCommandQuery : IRequest<SubscriptionPlanVm>
    {
    }
    public class GetAddSubscriptionPlanCommendQueryHandler : IRequestHandler<GetAddSubscriptionPlanCommandQuery, SubscriptionPlanVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddSubscriptionPlanCommendQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubscriptionPlanVm> Handle(GetAddSubscriptionPlanCommandQuery request, CancellationToken cancellationToken)
        {
            return new SubscriptionPlanVm
            {
                Countries = await _context.Countries.Where(x => x.IsActive).ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
                SubscriptionTypesHeader = await _context.SubscriptionTypes.Where(x => x.IsActive).ProjectTo<SubscriptionTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
            };
        }
    }
    }
