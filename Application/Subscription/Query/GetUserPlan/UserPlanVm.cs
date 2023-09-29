using System;
using System.Collections.Generic;
using System.Text;
using Application.Subscription.Command.AddUserSubscription;

namespace Application.Subscription.Query.GetUserPlan
{
    public class UserPlanVm
    {
        public IList<SubPlanDto> SubscriptionDtos { get; set; }
        public AddUserPlanCommand AddUserPlanCommand { get; set; }
        public UserSubPlanDto SelectedPlan { get; set; }
        public UserPlanVm()
        {
            SubscriptionDtos = new List<SubPlanDto>();
        }
    }
}
