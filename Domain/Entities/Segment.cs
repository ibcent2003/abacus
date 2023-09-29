using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Segment : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
       // public virtual ICollection<Heading> Headings { get; set; }
    }
}
