using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace TestSof.TaxCalculate.API.Filters
{
    public class ExceptionFilter: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;

            Log.Error(context.Exception, "{context.Exception}");
 
            context.ExceptionHandled = true;

            var response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.ContentType = "application/json";

            context.Result = new ObjectResult(new ApiResponse(message, null));
        }
    }
}