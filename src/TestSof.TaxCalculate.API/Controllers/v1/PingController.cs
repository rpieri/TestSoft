using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace TestSof.TaxCalculate.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        public string Ping() => "Pong";

        [HttpGet("[action]")]
        public string LogPing()
        {
            Log.Error("Pong");
            return "Logged";
        }

        [HttpGet("[action]")]
        public void ExceptionPing() => throw new NotImplementedException("Pong");
    }
}