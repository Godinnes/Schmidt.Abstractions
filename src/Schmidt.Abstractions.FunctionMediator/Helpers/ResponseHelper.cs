using Schmidt.Abstractions.FunctionMediator.Abstractions;
using Schmidt.Abstractions.FunctionMediator.Implementations;

namespace Schmidt.Abstractions.FunctionMediator.Helpers
{
    public static class ResponseHelper
    {
        public static IResponse Create(object result)
        {
            return new Response()
            {
                ObjectResult = result
            };
        }
    }
}
