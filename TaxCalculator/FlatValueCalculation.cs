namespace TaxCalculator
{

public class FlatValueCalculation: ITaxCalculation
    {
        public double Calculate(double amount, ITaxSettings settings)
        {
            //we expect a 'flat_amount', 'limit_amount', 'under_limit_rate' 
            double flatAmount = settings.GetValue<double>("flat_amount");
            double limitAmount = settings.GetValue<double>("limit_amount");
            double underLimitRate = settings.GetValue<double>("under_limit_rate");
            if (amount < limitAmount)
                return amount * underLimitRate;
            return flatAmount;
        }
    }
}