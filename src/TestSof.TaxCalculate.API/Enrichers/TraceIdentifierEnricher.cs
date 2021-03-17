using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace TestSof.TaxCalculate.API.Enrichers
{
    public class TraceIdentifierEnricher: ILogEventEnricher
    {
        private readonly HttpContext _context;

        public TraceIdentifierEnricher(HttpContext context) => _context = context;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            => EnrichUser(logEvent, propertyFactory, _context.TraceIdentifier);

        private static void EnrichUser(LogEvent logEvent, ILogEventPropertyFactory propertyFactory, string traceId)
            => logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TraceIdentifierEnricher", 
                traceId, true));
    }
}