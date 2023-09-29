using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class VehicleFactory
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ChassisNo { get; set; }
        public string AssessedHSCode { get; set; }
        public string Condition { get; set; }
        public string SpecialFeatures { get; set; }
        public int NoOfDoors { get; set; }
        public string ManufactureYear { get; set; }
        public string EngineCapacity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HDV { get; set; }
        public string VehicleType { get; set; }
        public string Currency { get; set; }
        public int SeatingCapacity { get; set; }
        public string FuelType { get; set; }
        public string Colour { get; set; }
    }
}
