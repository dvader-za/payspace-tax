namespace TaxCalculator
{

public class FlatValueCalculation: ITaxCalculation
    {
        public decimal Calculate(decimal amount, ITaxSettings settings)
        {
            //we expect a 'flat_amount', 'limit_amount', 'under_limit_rate' 
            var flatAmount = settings.GetValue<decimal>("flat_amount");
            var limitAmount = settings.GetValue<decimal>("limit_amount");
            var underLimitRate = settings.GetValue<decimal>("under_limit_rate");
            if (amount < limitAmount)
                return amount * underLimitRate;
            return flatAmount;
        }
    }
}