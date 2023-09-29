using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class AgencyDocument
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public int HSCodePoolId { get; set; }
        public HSCodePool  HSCodePool { get; set; }


    }
}
