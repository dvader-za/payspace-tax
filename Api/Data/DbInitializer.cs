using System;
using System.Linq;
using Api.Models;

namespace Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CalculatorContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            

            // Look for any students.
            if (context.CalculatorMappings.Any())
            {
                return;   // DB has been seeded
            }

            var calculatorMapping = new CalculatorMapping[]
            {
                new CalculatorMapping{PostalCode="7441", ClassName="TaxCalculator.ProgressiveTaxCalculation, TaxCalculator", Settings="{\"8350\":\"0.1\",\"33950\":\"0.15\",\"82250\":\"0.25\",\"171550\":\"0.28\",\"372950\":\"0.33\",\"100000000\":\"0.35\"}"},
                new CalculatorMapping{PostalCode="A100", ClassName="TaxCalculator.FlatValueCalculation, TaxCalculator", Settings="{\"flat_amount\":\"10000\",\"limit_amount\":\"200000\",\"under_limit_rate\":\"0.05\"}"},
                new CalculatorMapping{PostalCode="7000", ClassName="TaxCalculator.FlatRateTaxCalculation, TaxCalculator", Settings="{\"rate\":\"0.175\"}"},
                new CalculatorMapping{PostalCode="1000", ClassName="TaxCalculator.ProgressiveTaxCalculation, TaxCalculator", Settings="{\"8350\":\"0.1\",\"33950\":\"0.15\",\"82250\":\"0.25\",\"171550\":\"0.28\",\"372950\":\"0.33\",\"100000000\":\"0.35\"}"}
            };

            context.CalculatorMappings.AddRange(calculatorMapping);
            context.SaveChanges();

            var taxValues = new TaxValue[]
            {
                new TaxValue{Name="FlatRate Bob", PostalCode="7000", Income=100,Tax=(decimal)(100 * 0.175)},
                new TaxValue{Name="FlatValue tim", PostalCode="A100", Income=100000,Tax=5000},
                new TaxValue{Name="Progressive Sandra", PostalCode="7441", Income=100,Tax=152683.5m} 
            };

            context.TaxValues.AddRange(taxValues);
            context.SaveChanges();            
        }
    }
}