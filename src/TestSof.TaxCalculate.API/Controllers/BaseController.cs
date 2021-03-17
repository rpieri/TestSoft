using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestSoft.TaxCalculate.Application.CommandResults;

namespace TestSof.TaxCalculate.API.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private ActionResult ResponseCommand(CommandResult commandResult)
            => StatusCode((int) commandResult.StatusCode, commandResult.Response);

        protected async Task<IActionResult> SendCommand(IRequest<CommandResult> command)
            => ResponseCommand(await _mediator.Send(command));
    }
}