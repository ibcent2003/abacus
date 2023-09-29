using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class UserTariffExtraTax
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxValue { get; set; }
        public bool IsRate { get; set; }
        public int UserHSCodePoolId { get; set; }
        public UserHSCodePool UserHSCodePool { get; set; }
        public Guid TransactionId { get; set; }
    }
}
