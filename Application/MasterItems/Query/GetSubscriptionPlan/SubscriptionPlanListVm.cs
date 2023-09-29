using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Models;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionPlan
{
   public class SubscriptionPlanListVm : PageInfoModel
    {
        public IEnumerable<SubscriptionPlanDto> data { get; set; }
    }
}
