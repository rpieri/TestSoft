using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TestSoft.TaxCalculate.Application.CommandResults;
using TestSoft.TaxCalculate.Application.Commands;

namespace TestSoft.TaxCalculate.Application.Filters
{
    public class ExceptionFilter<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : Command<TRequest>
        where TResponse : CommandResult
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                var commandRequest = request as Command<TRequest>;
                if (commandRequest.Validate()) return await next();

                var log = new StringBuilder();
                var errors = commandRequest.ValidationResult.Errors.Select(e => e.ErrorMessage);
                log.AppendJoin(",", errors);
                Log.Information("{Log}", log);

                var response = CommandResult.WithStatusCode(HttpStatusCode.BadRequest, log.ToString());
                return await Task.FromResult(response as TResponse);
            }
            catch (Exception ex)
            {
                var message = "Unidentified failure";
                Log.Error(ex, "{ex.Message}");
                return CommandResult.InternalServerError(message) as TResponse;
            }
        }
    }
}