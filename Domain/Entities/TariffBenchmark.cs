using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
   public class TariffBenchmark
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string keywords { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public float ProductValue { get; set; }
        public string Unit { get; set; }
        public string Packaging   { get; set; }
        public float Qty { get; set; }
        public string SUOM { get; set; }
        [Column(TypeName = "decimal(20,4)")]
        public decimal UnitFOB { get; set; }
    }
}
