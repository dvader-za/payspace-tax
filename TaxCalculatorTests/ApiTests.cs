using NUnit.Framework;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Api.Models;

namespace TaxCalculatorTests
{
    public class ApiTests
    {
        private readonly HttpClientHandler _clientHandler;
        public ApiTests()
        {
            _clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
        }
        [Test]
        public void TestGet()
        {
            using var httpClient = new HttpClient(_clientHandler);
            using var response = httpClient.GetAsync("http://localhost:5000/api/TaxValue").Result;
            var apiResponse = response.Content.ReadAsStringAsync().Result;
            var values = JsonConvert.DeserializeObject<List<TaxValue>>(apiResponse);
            if (values.Count == 0)
                Assert.Fail("Should return values");
        }
    }
}