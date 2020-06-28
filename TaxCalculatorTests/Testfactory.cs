using NUnit.Framework;
using TaxCalculator;
using System;

namespace TaxCalculatorTests
{
    public class Testfactory
    {
        [Test]
        public void Stp()
        {
            //System.Console.WriteLine(typeof(ProgressiveTaxCalculation).FullName);
            ICalculatorFactory factory = new StaticCalculatorFactory();
            var result = factory.GetCalculator("7000");
            var tax = result.calculator.Calculate(100000, result.settings);
            Assert.AreEqual(tax, 17500, "Calculation error");
        }

        [Test]
        public void Dynamic()
        {
            var objectType = Type.GetType("TaxCalculator.ProgressiveTaxCalculation, TaxCalculator");
            var obj = Activator.CreateInstance(objectType);

        }
    }
}