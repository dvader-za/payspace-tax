using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Models;
using Api.Data;
using TaxCalculator;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxValueController : ControllerBase
    {
        private readonly ILogger<TaxValueController> _logger;
        private readonly CalculatorContext _context;
        private ICalculatorFactory _factory;
        public TaxValueController(ILogger<TaxValueController> logger, CalculatorContext context, ICalculatorFactory factory)
        {
            _logger = logger;
            _context = context;
            _factory = factory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxValue>>> Get()
        {
            return await Task.FromResult(_context.TaxValues.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<TaxValue>> Create(TaxCalculationInput taxInput)
        {
            try
            {
                var result = _factory.GetCalculator(taxInput.PostalCode);
                var tax = result.calculator.Calculate(taxInput.Income, result.settings);
                var addResult = _context.TaxValues.Add(new TaxValue { Name = taxInput.Name, PostalCode = taxInput.PostalCode, Income = taxInput.Income, Tax = tax });
                var commitResult = await _context.SaveChangesAsync();
                return addResult.Entity;
            }
            catch (Exception ex)
            {
                return new ApiErrorResponse();
            }
        }
    }
}
