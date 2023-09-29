using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
   public class HSCodePool //: AuditableEntity
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string Heading { get; set; }       
        public string Description { get; set; }  
        public string StandardUnitOfQuantity { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public bool IsActive { get; set; }
        public IList<Tariff> Tariffs { get; set; }
    }
}
