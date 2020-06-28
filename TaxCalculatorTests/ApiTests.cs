using NUnit.Framework;
using TaxCalculator;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Api.Models;

namespace TaxCalculatorTests
{
    public class ApiTests
    {
        private HttpClientHandler _clientHandler;
        public ApiTests()
        {
            _clientHandler = new HttpClientHandler();
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        [Test]
        public void TestGet()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5000/api/TaxValue").Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var values = JsonConvert.DeserializeObject<List<TaxValue>>(apiResponse);
                    if (values.Count == 0)
                        Assert.Fail("Should return values");
                }
            }
        }
    }
}