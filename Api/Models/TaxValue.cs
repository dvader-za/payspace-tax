using System;
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal Income { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        public TaxValue()
        {
            CreateDate = DateTime.Now;
        }
    }
}