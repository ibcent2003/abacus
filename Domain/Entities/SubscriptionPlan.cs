using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class SubscriptionPlan : AuditableEntity
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int ValidityPeriod { get; set; }
        public string Description { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
        public string Amout { get; set; }
        public int NoOfUse { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public bool IsActive { get; set; }
    }
}
