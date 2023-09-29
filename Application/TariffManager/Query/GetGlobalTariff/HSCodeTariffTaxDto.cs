using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.TariffManager.Query.GetGlobalTariff
{
    public class HSCodeTariffTaxDto :IMapFrom<HSCodeTariffTax>
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
    }
}
