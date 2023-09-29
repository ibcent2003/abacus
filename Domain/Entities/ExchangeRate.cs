using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class ExchangeRate : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime Week { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }

    }
}
