using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.MasterItems.Command.UpdateSubscriptionPlan;
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Application.MasterItems.Query.GetSubscriptionType;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetSubscriptionPlan
{
   public class SubscriptionPlanVm
    {
        public IList<CountryDto> Countries { get; set; }
        public IEnumerable<SubscriptionTypeDto> SubscriptionTypesHeader { get; set; }
        public UpdateSubscriptionPlanCommand UpdateCommand { get; set; }
    }
}
