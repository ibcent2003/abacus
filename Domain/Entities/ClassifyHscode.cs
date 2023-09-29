using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wbc.Domain.Entities
{
    public class ClassifyHscode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StandardUnitOfQuantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ImportDuty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VAT { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NHIL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LVY { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
