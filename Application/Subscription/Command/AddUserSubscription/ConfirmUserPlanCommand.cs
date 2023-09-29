using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Subscription.Command.AddUserSubscription
{
    public class ConfirmUserPlanCommand: IRequest<int>
    {
    }

    public class ConfirmUserPlanCommandHandler : IRequestHandler<ConfirmUserPlanCommand, int>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IApplicationDbContext _context;

        public ConfirmUserPlanCommandHandler(ICurrentUserService currentUserService, IApplicationDbContext context)
        {
            _currentUser = currentUserService;
            _context = context;
        }
        public async Task<int> Handle(ConfirmUserPlanCommand request, CancellationToken cancellationToken)
        {
            var currentTime = DateTime.UtcNow;
            var userId = _currentUser.GetUserId();

            var tempPlan = await _context.UserTemporaryPlans
                .FirstOrDefaultAsync(x => x.CreatedBy == userId && x.Created >= currentTime.AddMinutes(-3), cancellationToken);

            if (tempPlan == null)
                throw new NotFoundException(nameof(UserSubscription));

            var plan = await _context.UserSubscriptionPlans
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);

            var selectedPlan = await _context.SubscriptionPlans.Include(x => x.Country)
               .FirstOrDefaultAsync(x => x.Id == tempPlan.PlanId, cancellationToken);

            if (selectedPlan == null)
                throw new NotFoundException(nameof(SubscriptionPlan), tempPlan.Id);

            if (plan == null)
            {
                DateTime endDate = currentTime.AddDays(selectedPlan.ValidityPeriod);

                plan = new UserSubscriptionPlan
                {
                    UsageLeft = selectedPlan.NoOfUse,
                    PlanId = tempPlan.PlanId,
                    UserId = userId,
                    Created = currentTime,
                    StartDate = currentTime,
                    EndDate = endDate
                };

                  _context.UserSubscriptionPlans.Add(plan);
            }
            else
            {
                var endDate = plan.EndDate.AddDays(selectedPlan.ValidityPeriod);

                plan.PlanId = tempPlan.PlanId;
                plan.UsageLeft = (selectedPlan.NoOfUse + plan.UsageLeft);
                plan.LastModified = currentTime;
                plan.LastModifiedBy = userId;
                plan.EndDate = endDate;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return plan.Id;

        }
    }
}
