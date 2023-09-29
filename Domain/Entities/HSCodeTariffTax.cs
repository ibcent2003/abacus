using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
   public class HSCodeTariffTax : AuditableEntity
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public bool IsActive { get; set; }
    }
}
