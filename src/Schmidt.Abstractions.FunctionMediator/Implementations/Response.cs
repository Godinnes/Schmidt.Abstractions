using Microsoft.AspNetCore.Mvc;
using Schmidt.Abstractions.FunctionMediator.Abstractions;
using System.Net;

namespace Schmidt.Abstractions.FunctionMediator.Implementations
{
    internal class Response : IResponse
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public object ObjectResult { get; set; } = null;
        public string Message { get; set; }
        public IActionResult ActionResult
        {
            get
            {
                if (Status > HttpStatusCode.BadRequest)
                {
                    var badRequest = new ObjectResult(Message);
                    badRequest.StatusCode = (int)Status;
                    return badRequest;
                }

                if (ObjectResult == null)
                {
                    return new StatusCodeResult((int)Status);
                }

                var result = new ObjectResult(ObjectResult);
                result.StatusCode = (int)Status;
                return result;
            }
        }
    }
}
