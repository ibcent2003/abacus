using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.GeneralGoods.Query
{
    public class UserTariffDto : IMapFrom<UserTariff>
    {
        public int Id { get; set; }
        public decimal TariffValue { get; set; }
        public bool IsRate { get; set; }
        public UserHSCodePool HSCodeTariffTax { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTariff, UserTariffDto>()
                .ForMember(d => d.HSCodeTariffTax, opt => opt.MapFrom(s => s.HSCodeTariffTax));

        }
    }
}
