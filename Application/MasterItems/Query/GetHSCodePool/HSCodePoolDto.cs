using AutoMapper;
using System.Collections.Generic;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetHSCodePool
{
   public class HSCodePoolDto : IMapFrom<HSCodePool>
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StandardUnitOfQuantity { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<HSCodePool, HSCodePoolDto>()
            .ForMember(d => d.HSCode, opt => opt.MapFrom(s => s.HSCode))
            .ForMember(d => d.Heading, opt => opt.MapFrom(s => s.Heading))
            .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
            .ForMember(d => d.StandardUnitOfQuantity, opt => opt.MapFrom(s => s.StandardUnitOfQuantity))
            .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country.CountryName));
        }

    }
}
