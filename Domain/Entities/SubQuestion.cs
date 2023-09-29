using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class SubQuestion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }
        public int SetupTypeId { get; set; }
        public virtual SetupType SetupType { get; set; }
        public string Category { get; set; }
        public bool IsFinal { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
