using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class VehicleCategory 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
