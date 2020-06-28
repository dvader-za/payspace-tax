﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Api.Models;
using System.Text;
using System.Net;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClientHandler _clientHandler;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _clientHandler = new HttpClientHandler();
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5000/api/TaxValue").Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var values = JsonConvert.DeserializeObject<List<TaxValue>>(apiResponse);
                    return View(values);
                }
            }
        }

        [HttpPost]
        public IActionResult Create(IncomeViewModel tax)
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                var content = new StringContent(JsonConvert.SerializeObject(tax), Encoding.UTF8, "application/json");
                using (var response = httpClient.PostAsync("http://localhost:5000/api/TaxValue", content).Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        var values = JsonConvert.DeserializeObject<List<TaxValue>>(apiResponse);
                        return Ok(values);
                    }
                    else
                    {
                        _logger.LogError(response.ToString());
                        return BadRequest(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                    }
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}