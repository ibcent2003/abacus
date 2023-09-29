using System.Collections.Generic;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetSubscriptionPlan;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionType
{
   public class SubscriptionTypeDto : IMapFrom<Domain.Entities.SubscriptionType>
    {
        public SubscriptionTypeDto()
        {
           SubscriptionPlans = new List<SubscriptionPlanDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public bool IsActive { get; set; }
       public IList<SubscriptionPlanDto> SubscriptionPlans { get; set; }
    }
}
