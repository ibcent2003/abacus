using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class SetupType
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
