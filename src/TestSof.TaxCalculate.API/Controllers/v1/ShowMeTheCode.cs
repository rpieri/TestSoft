using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TestSof.TaxCalculate.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ShowMeTheCode : Controller
    {
        private readonly IConfiguration _configuration;

        public ShowMeTheCode(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get() => new OkObjectResult(_configuration["GitHub"]);
    }
}