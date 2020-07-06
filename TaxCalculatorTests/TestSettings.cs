using NUnit.Framework;
using TaxCalculator;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculatorTests
{
    public class TestSettings
    {
        private readonly ITaxSettings _settings = new DictionaryTaxSettings("{\"test1\":\"value1\",\"test2\":\"value2\",\"testint\":\"123\",\"1\":\"value1\",\"2\":\"value2\",\"3\":\"value3\",\"10\":\"value10\"}");

        [Test]
        public void TestStp()
        {
            string value1 = _settings.GetValue<string>("test1");
            string value2 = _settings.GetValue<string>("test2");
            int valueInt = _settings.GetValue<int>("testint");
            Assert.AreEqual(value1, "value1", "Values don't match");
            Assert.AreEqual(value2, "value2", "Values don't match");
            Assert.AreEqual(valueInt, 123, "Values don't match");
        }

        [Test]
        public void TestMissingValueFail()
        {
            try
            {
                var value1 = _settings.GetValue<string>("test3");
            }
            catch (CalculationException)
            {
                Assert.Pass();
            }
            Assert.Fail("Should throw exception on missing value");
        }

        [Test]
        public void TestIterator()
        {
            var results = new Dictionary<string, string>();
            foreach (var item in _settings.GetList())
                results[item.name] = item.value;

            Assert.AreEqual(results.Count, _settings.GetCount());
            foreach (var key in results.Keys.Where(key => results[key] != _settings.GetValue<string>(key)))
            {
                Assert.Fail("Value doesn't match");
            }
        }

        // [Test]
        // public void TestIteratorOrder()
        // {
        //     var names = new List<string>();
        //     foreach (var tuple in _settings.GetList())
        //         names.Add(tuple.name);

        //     CollectionAssert.IsOrdered(names);
        // }
    }
}