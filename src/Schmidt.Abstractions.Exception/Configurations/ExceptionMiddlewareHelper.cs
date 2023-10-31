using Microsoft.AspNetCore.Builder;
using Schmidt.Abstractions.Exception.Middlewares;

namespace Schmidt.Abstractions.Exception.Configurations
{
    public static class ExceptionMiddlewareHelper
    {
        public static void AddCustomExceptionsMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware(typeof(ErrorHandlingMiddleware));
        }
    }
}