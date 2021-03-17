using System.Net;

namespace TestSoft.TaxCalculate.Application.CommandResults
{
    public class CommandResult
    {
        private CommandResult(HttpStatusCode statusCode, object response)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public HttpStatusCode StatusCode { get; }
        public object Response { get; }

        public static CommandResult WithStatusCode(HttpStatusCode statusCode, object response)
            => new CommandResult(statusCode, response);
        
        public static CommandResult Ok(object response) => WithStatusCode(HttpStatusCode.OK, response);
        public static CommandResult NotFound(object response) => WithStatusCode(HttpStatusCode.NotFound, response);

        public static CommandResult InternalServerError(object response) =>
            WithStatusCode(HttpStatusCode.InternalServerError, response);


    }
}