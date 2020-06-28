using System;
using System.Linq;
using TaxCalculator;

namespace Api.Data
{
    public class DatabaseCalculatorFactory : ICalculatorFactory
    {
        private CalculatorContext _context;
        public DatabaseCalculatorFactory(CalculatorContext context)
        {
            _context = context;
        }
        public (ITaxCalculation calculator, ITaxSettings settings) GetCalculator(string postalCode)
        {
            var map = _context.CalculatorMappings.FirstOrDefault(m => m.PostalCode == postalCode);
            if (map == null)
                throw new CalculationException("Unknown postal code, please first add that postal code");
            var objectType = Type.GetType(map.ClassName);
            ITaxCalculation obj = (ITaxCalculation)Activator.CreateInstance(objectType);
            
            var settings = new DictionaryTaxSettings(map.Settings);
            return (calculator: obj, settings: settings);
        }

    }
}