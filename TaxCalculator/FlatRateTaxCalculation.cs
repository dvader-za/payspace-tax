namespace TaxCalculator
{
    public class FlatRateTaxCalculation : ITaxCalculation
    {
        public decimal Calculate(decimal amount, ITaxSettings settings)
        {
            //we expect a 'rate'
            var rate = settings.GetValue<decimal>("rate");
            return amount * rate;
        }
    }
}