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
using Wbc.Application.MasterItems.Command.UpdateSubscriptionPlan;
using Wbc.Application.MasterItems.Query.GetSubscriptionType;

namespace Application.MasterItems.Query.GetSubscriptionPlan
{
   public class GetUpdateSubscriptionPlanComandQuery : IRequest<SubscriptionPlanVm>
    {
        public int Id { get; set; }
    }
    public class GetUpdateSubscriptionPlanComandQueryHandler : IRequestHandler<GetUpdateSubscriptionPlanComandQuery, SubscriptionPlanVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateSubscriptionPlanComandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubscriptionPlanVm> Handle(GetUpdateSubscriptionPlanComandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionPlans.FindAsync(request.Id);
            return new SubscriptionPlanVm
            {
                UpdateCommand = _mapper.Map<UpdateSubscriptionPlanCommand>(entity),
                SubscriptionTypesHeader = await _context.SubscriptionTypes.Where(x => x.IsActive).ProjectTo<SubscriptionTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
                Countries = await _context.Countries.Where(x => x.IsActive).ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)

            };
        }
    }

    }
