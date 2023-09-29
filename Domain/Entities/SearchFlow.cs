using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class SearchFlow
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }       
        public int HeaderId { get; set; }
        public virtual Header Header { get; set; }       
        public string Flow { get; set; }
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

    }
}
