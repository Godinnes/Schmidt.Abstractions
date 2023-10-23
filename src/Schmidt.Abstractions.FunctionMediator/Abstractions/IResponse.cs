using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Schmidt.Abstractions.FunctionMediator.Abstractions
{
    public interface IResponse
    {
        public HttpStatusCode Status { get; }
        public object ObjectResult { get; }
        public string Message { get; }
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
                    return new StatusCodeResult((int)HttpStatusCode.NoContent);
                }

                var result = new ObjectResult(ObjectResult);
                result.StatusCode = (int)Status;
                return result;
            }
        }
    }
}
