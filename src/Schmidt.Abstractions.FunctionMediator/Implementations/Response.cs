using Schmidt.Abstractions.FunctionMediator.Abstractions;
using System.Net;

namespace Schmidt.Abstractions.FunctionMediator.Implementations
{
    internal class Response : IResponse
    {
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public object ObjectResult { get; set; } = null;
        public string Message { get; set; }
    }
}
