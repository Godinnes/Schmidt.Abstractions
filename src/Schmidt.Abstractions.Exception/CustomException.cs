using System.Net;

namespace Schmidt.Abstractions.Exception
{
    public class CustomException : System.Exception
    {
        public override string Message { get; }
        public HttpStatusCode HttpStatusCode { get; }
        public CustomException(string message, HttpStatusCode httpStatus = HttpStatusCode.BadRequest)
        {
            Message = message;
            HttpStatusCode = httpStatus;
        }
    }
}
