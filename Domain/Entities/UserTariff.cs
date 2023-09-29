using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
  public class UserTariff
    {
        public int Id { get; set; }
        public int HsCodePoolId { get; set; }
        public virtual HSCodePool HSCodePool { get; set; }
        public int HSCodeTariffTaxId { get; set; }
        public virtual HSCodeTariffTax HSCodeTariffTax { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal TariffValue { get; set; }
        public bool IsRate { get; set; }
        public Guid TransactionId { get; set; }
        public string UserId { get; set; }
    }
}
