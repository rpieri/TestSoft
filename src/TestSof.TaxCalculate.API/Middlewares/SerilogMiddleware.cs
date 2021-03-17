using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog.Context;
using TestSof.TaxCalculate.API.Enrichers;

namespace TestSof.TaxCalculate.API.Middlewares
{
    public class SerilogMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (LogContext.Push(new TraceIdentifierEnricher(context)))
            {
                await _next(context);
            }
        }
    }
}