using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class TaxValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public decimal Income { get; set; }
        public decimal Tax { get; set; }

        public TaxValue()
        {
            CreateDate = DateTime.Now;
        }
    }
}