using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class HSCodeRecord
    {
        public int Id { get; set; }
        public int HsCodePoolId { get; set; }
        public virtual HSCodePool HSCodePool { get; set; }
        public string Docs { get; set; }       
        public int DocumentCategoryId { get; set; }
        public virtual DocumentCategory DocumentCategory { get; set; }
    }
}
