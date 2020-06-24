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
            var tax = CalculatorFactory.GetTaxValue(100000, "7000");
        }
    }
}