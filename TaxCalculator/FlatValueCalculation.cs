namespace TaxCalculator
{

public class FlatValueCalculation: ITaxCalculation
    {
        public decimal Calculate(decimal amount, ITaxSettings settings)
        {
            //we expect a 'flat_amount', 'limit_amount', 'under_limit_rate' 
            decimal flatAmount = settings.GetValue<decimal>("flat_amount");
            decimal limitAmount = settings.GetValue<decimal>("limit_amount");
            decimal underLimitRate = settings.GetValue<decimal>("under_limit_rate");
            if (amount < limitAmount)
                return amount * underLimitRate;
            return flatAmount;
        }
    }
}