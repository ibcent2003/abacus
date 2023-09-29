using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.GeneralGoods.Query
{
   public class UserTariffExtraTaxDto : IMapFrom<UserTariffExtraTax>
    {
        public int Id { get; set; }
        public string TaxName { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal TaxValue { get; set; }

        public int UserHSCodePoolId { get; set; }
        public UserHSCodePoolDto UserHSCodePoolDto { get; set; }
        public Guid TransactionId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTariffExtraTax, UserTariffExtraTaxDto>()
                .ForMember(d => d.UserHSCodePoolDto, opt => opt.MapFrom(s => s.UserHSCodePool));

        }
    }
}
