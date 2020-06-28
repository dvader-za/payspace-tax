using System;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models
{    
    public class IncomeViewModel
    {
        public IncomeViewModel()
        {
            
        }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public decimal Income { get; set; }
    }
}
