using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Agency : AuditableEntity
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string logo { get; set; }
        public string AgencyCode { get; set; }
        public string Description { get; set; }      
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
