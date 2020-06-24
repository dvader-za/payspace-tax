namespace TaxCalculator
{
    public class FlatRateTaxCalculation : ITaxCalculation
    {
        public double Calculate(double amount, ITaxSettings settings)
        {
            //we expect a 'rate'
            double rate = settings.GetValue<double>("rate");
            return amount * rate;
        }
    }
}