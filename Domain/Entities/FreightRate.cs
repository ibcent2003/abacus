using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class FreightRate
    {
        public int Id { get; set; }
        public int VehicleCategoryId { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }
        public int MinimumCC { get; set; }
        public int MaximumCC { get; set; }

    }
}
