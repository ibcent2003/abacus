using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class VehicleSearchPool
    {
        public int Id { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string VehicleTypeName { get; set; }
        public string SpecialFeatureName { get; set; }
        public int SeatingCapacity { get; set; }
        public string EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }
        public string OwnedBy { get; set; }
        public string UserId { get; set; }
        public string CurrencyName { get; set; }      
        [Column(TypeName = "decimal(18,2)")]
        public decimal? HDV { get; set; }
        public DateTime TransactonDate { get; set; }
        public Guid TransactionId { get; set; }
        public string Status { get; set; }
        public string DutyResult { get; set; }
        public string CalculatedBy { get; set; }
        public DateTime CalculatedDate { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string ChassisNo { get; set; }
        public string AssessedHSCode { get; set; }
        public int NoOfDoor { get; set; }

    }
}
