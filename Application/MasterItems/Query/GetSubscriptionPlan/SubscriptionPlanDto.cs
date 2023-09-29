using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Application.MasterItems.Query.GetSubscriptionType;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetSubscriptionPlan
{
    public class SubscriptionPlanDto : IMapFrom<Domain.Entities.SubscriptionPlan>
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int ValidityPeriod { get; set; }
        public string Description { get; set; }
        public SubscriptionTypeDto SubscriptionType { get; set; }
        public string SubscriptionTypeName { get; set; }
        public string Amout { get; set; }
        public int NoOfUse { get; set; }
         public CountryDto Country { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.SubscriptionPlan, SubscriptionPlanDto>()
                .ForMember(d => d.SubscriptionTypeName, opt => opt.MapFrom(s => s.SubscriptionType.Name))
                .ForMember(x=>x.CountryName, opt=>opt.MapFrom(s=>s.Country.CountryName));

        }

    }

    
}
