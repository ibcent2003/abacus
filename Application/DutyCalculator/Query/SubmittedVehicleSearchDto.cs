using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.DutyCalculator.Query
{
   public class SubmittedVehicleSearchDto : IMapFrom<VehicleSearchPool>
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string VehicleTypeName { get; set; }
        public string SpecialFeatureName { get; set; }
        public int SeatingCapacity { get; set; }
        public string EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }
        public string OwnedBy { get; set; }
        public string UserId { get; set; }
        public int CurrencyId { get; set; }      
        public decimal HDV { get; set; }
        public DateTime TransactonDate { get; set; }
        public Guid TransactionId { get; set; }
        public string CountryName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.VehicleSearchPool, SubmittedVehicleSearchDto>()
                .ForMember(x => x.CountryName, opt => opt.MapFrom(s => s.Country.CountryName));

        }
    }
}
