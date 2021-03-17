using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TestSof.TaxRate.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/taxaJuros")]
    public class TaxRateController : Controller
    {
        private readonly IConfiguration _configuration;

        public TaxRateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var taxRate = _configuration["TaxRate"];
            return Ok(Convert.ToDouble(taxRate));
        }
    }
}