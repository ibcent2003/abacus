using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
   public class VehicleSpecialFeature : AuditableEntity
    {
        public int Id { get; set; }
        public string SpecialFeatureName { get; set; }
        public bool IsActive { get; set; }
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
