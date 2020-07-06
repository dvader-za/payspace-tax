using NUnit.Framework;
using TaxCalculator;

namespace TaxCalculatorTests
{
    public class FlatValueTests
    {
        private readonly ITaxSettings _settings = new DictionaryTaxSettings("{\"flat_amount\":\"10000\",\"limit_amount\":\"200000\",\"under_limit_rate\":\"0.05\"}");

        [Test]
        public void TestStp()
        {
            var value = new FlatValueCalculation().Calculate(300000, _settings);
            Assert.AreEqual(value, 10000, "Calculation error");
        }

        [Test]
        public void TestBelowLimitAmount()
        {
            var value = new FlatValueCalculation().Calculate(100000, _settings);
            Assert.AreEqual(value, 5000, "Calculation error");
        }

          [Test]
        public void TestAtLimitAmount()
        {
            var value = new FlatValueCalculation().Calculate(200000, _settings);
            Assert.AreEqual(value, 10000, "Calculation error");
        }
    }
}