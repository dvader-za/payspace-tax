using System;
using System.Collections.Generic;

namespace TaxCalculator
{
    public static class CalculatorFactory
    {
        private static Dictionary<string, ITaxCalculation> _calculators = new Dictionary<string, ITaxCalculation>();
        private static Dictionary<string, ITaxSettings> _settings = new Dictionary<string, ITaxSettings>();

        public static ITaxCalculation GetCalculator(string postalCode)
        {
            if (!_calculators.ContainsKey(postalCode))
            {
                ITaxCalculation calculator;
                switch (postalCode)
                {
                    case "7441": calculator = new ProgressiveTaxCalculation(); break;
                    case "A100": calculator = new FlatValueCalculation(); break;
                    case "7000": calculator = new FlatRateTaxCalculation(); break;
                    case "1000": calculator = new ProgressiveTaxCalculation(); break;
                    default: throw new CalculationException("Unknown postal code");
                }
                _calculators[postalCode] = calculator;
            }
            return _calculators[postalCode];
        }

        public static ITaxSettings GetSettings(string postalCode)
        {
            if (!_settings.ContainsKey(postalCode))
            {
                ITaxSettings settings;
                switch (postalCode)
                {
                    case "7441": settings = new DictionaryTaxSettings("{\"8350\":\"0.1\",\"33950\":\"0.15\",\"82250\":\"0.25\",\"171550\":\"0.28\",\"372950\":\"0.33\",\"100000000\":\"0.35\"}"); break;
                    case "A100": settings = new DictionaryTaxSettings("{\"flat_amount\":\"10000\",\"limit_amount\":\"200000\",\"under_limit_rate\":\"0.05\"}"); break;
                    case "7000": settings = new DictionaryTaxSettings("{\"rate\":\"0.175\"}"); break;
                    case "1000": settings = new DictionaryTaxSettings("{\"8350\":\"0.1\",\"33950\":\"0.15\",\"82250\":\"0.25\",\"171550\":\"0.28\",\"372950\":\"0.33\",\"100000000\":\"0.35\"}"); break;
                    default: throw new CalculationException("Unknown postal code");
                }
                _settings[postalCode] = settings;
            }
            return _settings[postalCode];
        }

        public static double GetTaxValue(double amount, string postalCode){
            return GetCalculator(postalCode).Calculate(amount, GetSettings(postalCode));
        }
    }

}

