using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Domain.Entities;

namespace Wbc.Application.GeneralGoods.Query
{
     public class HSCodePoolDto : IMapFrom<HSCodePool>
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StandardUnitOfQuantity { get; set; }       
        public String CountryName { get; set; }       
        public CountryDto Country { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.HSCodePool, HSCodePoolDto>()
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country.CountryName));

        }

    }
}
