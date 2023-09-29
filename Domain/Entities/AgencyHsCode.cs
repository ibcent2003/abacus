using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class AgencyHsCode
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public int HsCodePoolId { get; set; }
        public virtual HSCodePool HSCodePool { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }

        public string Code { get; set; }
    }
}
