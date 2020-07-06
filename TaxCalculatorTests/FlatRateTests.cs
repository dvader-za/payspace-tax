using NUnit.Framework;
using TaxCalculator;

namespace TaxCalculatorTests
{
    public class FlatRateTests
    {
        private readonly ITaxSettings _settings = new DictionaryTaxSettings("{\"rate\":\"0.175\"}");
        [Test]
        public void TestStp()
        {
            var value = new FlatRateTaxCalculation().Calculate(100, _settings);
            Assert.AreEqual(value, 100 * 0.175, "Calculation error");
        }
    }
}