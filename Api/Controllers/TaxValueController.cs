using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;
using TaxCalculator;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxValueController : ControllerBase
    {
        private readonly CalculatorContext _context;
        private readonly ICalculatorFactory _factory;
        public TaxValueController(CalculatorContext context, ICalculatorFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            try
            {
                var result = await Task.FromResult(_context.TaxValues.ToList());
                return new ActionResult<ApiResponse>(new ApiResponse { Success = true, Result = result });
            }
            catch (Exception ex)
            {
                return new ActionResult<ApiResponse>(new ApiResponse { Success = false, Message = ex.Message, Details = ex.Source, StackTrace = ex.StackTrace });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(TaxCalculationInput taxInput)
        {
            try
            {
                var result = _factory.GetCalculator(taxInput.PostalCode);
                var tax = result.calculator.Calculate(taxInput.Income, result.settings);
                var addResult = await _context.TaxValues.AddAsync(new TaxValue { Name = taxInput.Name, PostalCode = taxInput.PostalCode.ToUpper(), Income = taxInput.Income, Tax = tax });
                var commitResult = await _context.SaveChangesAsync();
                return new ActionResult<ApiResponse>(new ApiResponse { Success = true, Result = addResult.Entity });
            }
            catch (Exception ex)
            {
                return new ActionResult<ApiResponse>(new ApiResponse { Success = false, Message = ex.Message, Details = ex.Source, StackTrace = ex.StackTrace });
            }
        }
    }
}
