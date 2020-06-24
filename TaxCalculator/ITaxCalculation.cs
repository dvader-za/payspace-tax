namespace TaxCalculator
{
    public interface ITaxCalculation
    {
        double Calculate(double amount, ITaxSettings settings);
    }
}