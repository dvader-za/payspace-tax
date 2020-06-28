using NUnit.Framework;
using TaxCalculator;
using System;

namespace TaxCalculatorTests
{
    public class FlatRateTests
    {
        private ITaxSettings _settings = new DictionaryTaxSettings("{\"rate\":\"0.175\"}");
        [Test]
        public void TestStp()
        {
            decimal value = new FlatRateTaxCalculation().Calculate(100, _settings);
            Assert.AreEqual(value, 100 * 0.175, "Calculation error");
        }
    }
}