using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Application.MasterItems.Query.GetCurrency;
using Wbc.Domain.Entities;

namespace Wbc.Application.GeneralGoods.Query
{
    public class UserHSCodePoolDto : IMapFrom<UserHSCodePool>
    {
        public int Id { get; set; }
        public string HsCode { get; set; }      
        public decimal FOB { get; set; }     
        public decimal Freight { get; set; }     
        public decimal Insurance { get; set; }
        public string CurrencyName { get; set; }
        public CurrencyDto Currency { get; set; }
        public string CountryName { get; set; }
        public CountryDto Country { get; set; }

        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid TransactionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserHSCodePool, UserHSCodePoolDto>()
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country.CountryName))
                .ForMember(d => d.CurrencyName, opt => opt.MapFrom(s => s.Currency.Name));

        }
    }
}
