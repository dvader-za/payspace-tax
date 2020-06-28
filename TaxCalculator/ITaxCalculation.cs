namespace TaxCalculator
{
    public interface ITaxCalculation
    {
        decimal Calculate(decimal amount, ITaxSettings settings);
    }
}