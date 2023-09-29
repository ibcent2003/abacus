using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class FreightOverage
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public string OverAgeName { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal OverAgeRate { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public string FreightName { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }
        public int MinimumCC { get; set; }
        public int MaximumCC { get; set; }
        public string HsCode { get; set; }
    }
}
