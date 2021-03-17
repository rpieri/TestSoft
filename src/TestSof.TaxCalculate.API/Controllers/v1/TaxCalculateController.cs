using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestSof.TaxCalculate.API.ViewModels;

namespace TestSof.TaxCalculate.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/calculajuros")]
    public class TaxCalculateController : BaseController
    {
        public TaxCalculateController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaxCalculateViewModel viewModel)
            => await SendCommand(viewModel.Mapping());
    }
}