using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.Subscription.Query.GetUserPlan
{
    public class SubPlanDto : IMapFrom<SubscriptionPlan>
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public int NoOfUse { get; set; }
        public int Validity { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public void Mapping(Profile profile)
        {

            profile.CreateMap<SubscriptionPlan, SubPlanDto>()
                .ForMember(d => d.Currency, opt => opt.MapFrom(s => s.Country.CurrencyName))
                .ForMember(d => d.Validity, opt => opt.MapFrom(s => s.ValidityPeriod))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amout));
        }
    }
}
