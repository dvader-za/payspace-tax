using NUnit.Framework;
using TaxCalculator;
using System;

namespace TaxCalculatorTests
{
    public class ProgressiveTests
    {
        private ITaxSettings _settings = new DictionaryTaxSettings("{\"8350\":\"0.1\",\"33950\":\"0.15\",\"82250\":\"0.25\",\"171550\":\"0.28\",\"372950\":\"0.33\",\"100000000\":\"0.35\"}");

        [Test]
        public void TestStp()
        {
            decimal value = new ProgressiveTaxCalculation().Calculate(100, _settings);
            Assert.AreEqual(value, 100 * 0.1, "Calculation error");
        }

        [Test]
        public void TestExtensiveMustPass()
        {
            Assert.AreEqual(new ProgressiveTaxCalculation().Calculate(100, _settings), 100 * 0.1, "Calculation error");
            Assert.AreEqual(new ProgressiveTaxCalculation().Calculate(8350, _settings), 8350 * 0.1, "Calculation error");
            Assert.AreEqual(new ProgressiveTaxCalculation().Calculate(30000, _settings), (8350 * 0.1) + ((30000 - 8350) * 0.15), "Calculation error");
            Assert.AreEqual(new ProgressiveTaxCalculation().Calculate(80000, _settings), (8350 * 0.1) + ((33950 - 8350) * 0.15) + ((80000 - 33950) * 0.25), "Calculation error");
            Assert.AreEqual(new ProgressiveTaxCalculation().Calculate(500000, _settings),
            (8350 * 0.1) +
            ((33950 - 8350) * 0.15) +
            ((82250 - 33950) * 0.25) +
            ((171550 - 82250) * 0.28) +
            ((372950 - 171550) * 0.33) +
            ((500000 - 372950) * 0.35)
            , "Calculation error");
        }

[Test]
        public void TestDifferentValues(){
            ITaxSettings settings = new DictionaryTaxSettings("{\"10000\":\"0.1\",\"20000\":\"0.2\",\"1000000\":\"0.3\"}");
            ITaxCalculation calc = new ProgressiveTaxCalculation();
            var value1 = calc.Calculate(20000, settings);
            var value2 = calc.Calculate(25000, settings);
            Assert.AreEqual(value1, 3000, "Calculation error");
            Assert.AreEqual(value2, 4500, "Calculation error");
        }
    }
}