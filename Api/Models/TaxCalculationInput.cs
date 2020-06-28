using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class TaxCalculationInput
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Income { get; set; }        
    }
}