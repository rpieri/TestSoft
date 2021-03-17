using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestSoft.TaxCalculate.Application.CommandResults;
using TestSoft.TaxCalculate.Service;

namespace TestSoft.TaxCalculate.Application.Commands.TaxCalculate
{
    public class TaxCalculateCommandHandler : IRequestHandler<TaxCalculateCommand, CommandResult>
    {
        private readonly ITaxCalculateService _service;

        public TaxCalculateCommandHandler(ITaxCalculateService service)
        {
            _service = service;
        }


        public async Task<CommandResult> Handle(TaxCalculateCommand request, CancellationToken cancellationToken)
        {
            var taxRate = await _service.GetTaxRate();
            if(!taxRate.HasValue)
                return CommandResult.InternalServerError("Has a error to get tax rate");

            var taxCalculate = request.Value * Math.Pow(taxRate.Value + 1, request.Month);
            var roundValue = Math.Round((Decimal) taxCalculate, 2, MidpointRounding.ToEven);
            return CommandResult.Ok(roundValue);
        }
    }
}