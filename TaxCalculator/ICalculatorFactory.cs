namespace TaxCalculator
{
    public interface ICalculatorFactory
    {
        (ITaxCalculation calculator, ITaxSettings settings) GetCalculator(string postalCode);        
    }
}