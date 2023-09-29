using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VehicleCategoryId { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public bool IsActive { get; set; }
    }
}
