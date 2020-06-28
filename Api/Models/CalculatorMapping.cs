using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class CalculatorMapping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string ClassName { get; set; }
        public string Settings { get; set; }
    }
}