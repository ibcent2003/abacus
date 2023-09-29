using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class Header
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUsedInSearchFlow { get; set; }
        public string Description { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
       
    }
}
