using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class TaxCalculationInput
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public decimal Income { get; set; }        
    }
}