using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class CalculatedDuty
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string YearOfManufacture { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HDV { get; set; }
        public string CC { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DepreciationAllow { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FOB { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Freight { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Insurance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CIFForginCurrency { get; set; }
        public string CurrencyName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExchangeRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CIFLocalCurrency { get; set; }
        public string HsCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ImportDuty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProcessingFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VAT { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Shipper { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NHIL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestCharge { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ecowas { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetworkCharge { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal EXIM { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetChargeVAT { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExamFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetChargeNHIL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SpecialImpLevy { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OverAgePenalty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDutyBeforeDeduction { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDutyAfterDeduction { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid TransactionId { get; set; }
        public string SpecialFeatures { get; set; }
        public int NoOfDoors { get; set; }
        public int SeatingCapacity { get; set; }
        public string FuelType { get; set; }
        public string Color { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }


    }
}
