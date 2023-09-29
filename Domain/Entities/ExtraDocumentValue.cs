using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class ExtraDocumentValue
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public int AgencyHsCodeId { get; set; }
        public virtual AgencyHsCode AgencyHsCode { get; set; }
        public string ExtraName { get; set; }
        public string ExtraValue { get; set; }
    }
}
