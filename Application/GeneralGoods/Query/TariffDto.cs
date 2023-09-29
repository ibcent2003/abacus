using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.GeneralGoods.Query
{
    public class TariffDto : IMapFrom<Tariff>
    {
        public int Id { get; set; }       
        public decimal TariffValue { get; set; }
        public bool IsRate { get; set; }
        public HSCodeTariffTaxDto HSCodeTariffTax { get; set; }       
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tariff, TariffDto>()
                .ForMember(d => d.HSCodeTariffTax, opt => opt.MapFrom(s => s.HSCodeTariffTax));

        }
    }
}
