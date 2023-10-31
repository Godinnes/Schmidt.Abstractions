using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Schmidt.Abstractions.Exception.Configurations
{
    public class ExceptionFunctionMiddleware : IFunctionsWorkerMiddleware
    {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(FunctionContext context, System.Exception ex)
        {
            //HttpStatusCode code = HttpStatusCode.InternalServerError;

            //if (ex is CustomException) code = (ex as CustomException).HttpStatusCode;

            //string result = JsonConvert.SerializeObject(new { ex.Message });

            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)code;

            //context.BindingContext.

            return null;
        }
    }
}
