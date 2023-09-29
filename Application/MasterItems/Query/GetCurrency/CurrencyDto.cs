using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetCurrency
{
   public class CurrencyDto : IMapFrom<Currency>
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }       
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
