using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class DocumentCategory : AuditableEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
      // public int DocumentTypeId { get; set; }
    //  public virtual DocumentType DocumentType { get; set; }
        public bool IsActive { get; set; }
    }
}
