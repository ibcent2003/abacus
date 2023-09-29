using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
   public class AllCalculateDutyDto : IMapFrom<CalculatedDuty>
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string YearOfManufacture { get; set; }
        public decimal HDV { get; set; }
        public string CC { get; set; }
        public decimal DepreciationAllow { get; set; }
        public decimal FOB { get; set; }
        public decimal Freight { get; set; }
        public decimal Insurance { get; set; }
        public decimal CIFForginCurrency { get; set; }
        public string CurrencyName { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal CIFLocalCurrency { get; set; }
        public string HsCode { get; set; }
        public decimal ImportDuty { get; set; }
        public decimal ProcessingFee { get; set; }
        public decimal VAT { get; set; }
        public decimal Shipper { get; set; }
        public decimal NHIL { get; set; }
        public decimal InterestCharge { get; set; }
        public decimal Ecowas { get; set; }
        public decimal NetworkCharge { get; set; }
        public decimal EXIM { get; set; }
        public decimal NetChargeVAT { get; set; }
        public decimal ExamFee { get; set; }
        public decimal NetChargeNHIL { get; set; }
        public decimal SpecialImpLevy { get; set; }
        public decimal OverAgePenalty { get; set; }
        public decimal TotalDutyBeforeDeduction { get; set; }
        public decimal TotalDutyAfterDeduction { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid TransactionId { get; set; }
        public string SpecialFeatures { get; set; }
        public int NoOfDoors { get; set; }
        public int SeatingCapacity { get; set; }
        public string FuelType { get; set; }
        public string Color { get; set; }
    }
}
