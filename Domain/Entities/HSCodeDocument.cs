using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class HSCodeDocument
    {
        public int Id { get; set; }
        public int HsCodePoolId { get; set; }
        public virtual HSCodePool HSCodePool { get; set; }
        public string Docs { get; set; }
      // public int DocumentTypeId { get; set; }
       // public virtual DocumentType DocumentType { get; set; }
        public int DocumentCategoryId { get; set; }
        public virtual DocumentCategory  DocumentCategory { get; set; }
    }
}
