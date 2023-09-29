using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class GuestUser
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int NoOfUse { get; set; }
        public DateTime AccessDate { get; set; }
    }
}
