using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Schmidt.Abstractions.FunctionMediator.Abstractions
{
    public interface IResponse
    {
        public HttpStatusCode Status { get; }
        public object ObjectResult { get; }
        public IActionResult ActionResult { get; }
    }
}
