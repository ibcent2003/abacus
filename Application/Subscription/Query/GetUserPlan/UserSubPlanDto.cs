using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Subscription.Query.GetUserPlan
{
    public class UserSubPlanDto : IMapFrom<UserSubscriptionPlan>
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int UsageLeft { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public void Mapping(Profile profile)
        {

            profile.CreateMap<UserSubscriptionPlan, UserSubPlanDto>()
                .ForMember(d => d.PlanName, opt => opt.MapFrom(s => s.SubscriptionPlan.PlanName));
        }
    }
}
