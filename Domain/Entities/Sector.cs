using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Sector : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RomanFigure { get; set; }
    }
}
