using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class Heading
    {
        public int Id { get; set; }
       // public int ChapterId { get; set; }
       // public virtual Chapter Chapter { get; set; }
        public string Name { get; set; }      
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
