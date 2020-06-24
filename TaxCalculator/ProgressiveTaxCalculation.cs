using System;

namespace TaxCalculator
{
    public class ProgressiveTaxCalculation : ITaxCalculation
    {
        public double Calculate(double amount, ITaxSettings settings)
        {
            //we expect a table of values in the format: from:to
            //the from starts from 0 and extends to the max value (100000000)

            double currentMin = 0;
            double currentTax = 0;
            foreach (var bracket in settings.GetList())
            {
                if (amount < currentMin)
                    break;
                try
                {
                    double upperBound = Convert.ToDouble(bracket.name);
                    double taxPerc = Convert.ToDouble(bracket.value);
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