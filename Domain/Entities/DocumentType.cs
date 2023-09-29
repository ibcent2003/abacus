using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
   public class DocumentType : AuditableEntity
    {
        public int Id { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentTag { get; set; }          
        public bool IsActive { get; set; }

    }
}
