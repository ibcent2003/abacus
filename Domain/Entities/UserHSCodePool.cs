using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class UserHSCodePool
    {
        public int Id { get; set; }
        public string HsCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FOB { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Freight { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Insurance { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid TransactionId { get; set; }
        public string StandardUnitOfQuantity { get; set; }

        public int ExportingCountryId { get; set; }        
        public string Keyword { get; set; }
        public string ContainerSize { get; set; }

        public IList<UserTariffExtraTax> userTariffExtraTaxes { get; set; }




    }
}
