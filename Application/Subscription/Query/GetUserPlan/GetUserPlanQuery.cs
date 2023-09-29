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
using Application.Common.Interfaces;
using Application.Subscription.Command.AddUserSubscription;
using System.Security.Cryptography.X509Certificates;

namespace Application.Subscription.Query.GetUserPlan
{
    public class GetUserPlanQuery : IRequest<UserPlanVm>
    {
    }

    public class GetUserPlanQueryHandler : IRequestHandler<GetUserPlanQuery, UserPlanVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public GetUserPlanQueryHandler(IApplicationDbContext context, IMapper mapper,
            ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        public async Task<UserPlanVm> Handle(GetUserPlanQuery request, CancellationToken cancellationToken)
        {
            UserSubPlanDto selectedPlan = null;
            
            var plans = await _context.SubscriptionPlans.Where(x => x.IsActive == true)
                .Include(s => s.Country)
                .ProjectTo<SubPlanDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var userId = _currentUser.GetUserId();
            var addUserPlan = new AddUserPlanCommand { Id = 0, NumberOfUse = 0, PlanId = 0 };

            if(userId != null)
            {
                var currentPlan = await _context.UserSubscriptionPlans
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
                if (currentPlan != null)
                {
                    addUserPlan.Id = currentPlan.Id;
                    var planName = plans.FirstOrDefault(x => x.Id == currentPlan.Id).PlanName;
                    selectedPlan = _mapper.Map<UserSubPlanDto>(currentPlan);

                    selectedPlan.PlanName = planName;
                }
               
            }

            return new UserPlanVm
            {
                SubscriptionDtos = plans,
                AddUserPlanCommand = addUserPlan,
                SelectedPlan = selectedPlan
            };
        }
    }
}
