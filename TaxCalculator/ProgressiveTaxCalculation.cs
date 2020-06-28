using System;

namespace TaxCalculator
{
    public class ProgressiveTaxCalculation : ITaxCalculation
    {
        public decimal Calculate(decimal amount, ITaxSettings settings)
        {
            //we expect a table of values in the format: from:to
            //the from starts from 0 and extends to the max value (100000000)

            decimal currentMin = 0;
            decimal currentTax = 0;
            foreach (var bracket in settings.GetList())
            {
                if (amount < currentMin)
                    break;
                try
                {
                    decimal upperBound = Convert.ToDecimal(bracket.name);
                    decimal taxPerc = Convert.ToDecimal(bracket.value);
                    var bracketAmount = Math.Min(amount, upperBound) - currentMin;
                    var taxAmount = bracketAmount * taxPerc;
                    currentTax += taxAmount;
                    currentMin = upperBound;
                }
                catch (Exception) { }
            }
            return currentTax;
        }
    }
}