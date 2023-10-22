using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Schmidt.Abstractions.FunctionMediator.Abstractions;
using System;
using System.ComponentModel;
using System.Linq;

namespace Schmidt.Abstractions.FunctionMediator.Helpers
{
    internal static class HttpRequestConverterExtention
    {
        internal static T ToCommand<T>(this HttpRequest request)
           where T : ICommand, new()
        {
            var command = default(T);
            if (request.Body.CanSeek)
            {
                var inputResponse = ReadStream<T>.ReadRawStream(request.Body, "application/json");
                command = inputResponse;
            }
            else
            {
                command = new T();
            }

            SetValuesFromRoute(command, request.HttpContext.GetRouteData());
            SetValuesFromQuery(command, request.HttpContext);

            return command;
        }
        private static void SetValuesFromRoute<T>(T command, RouteData routeData)
        {
            if (routeData.Values.Any() == false)
                return;

            foreach (var value in routeData.Values)
            {
                if (value.Value.ToString() == @"null")
                    throw new ArgumentNullException();
                SetPropertyValue(command, value.Key, value.Value);
            }
        }
        private static void SetValuesFromQuery<T>(T command, HttpContext context)
        {
            if (!context.Request.QueryString.HasValue)
                return;
            foreach (var value in context.Request.Query)
            {
                SetPropertyValue(command, value.Key, value.Value);
            }
        }
        private static void SetPropertyValue<T>(T command, string key, object value)
        {
            var property = command.GetType().GetProperty(key, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (property == null)
                return;
            TypeConverter obj = TypeDescriptor.GetConverter(property.MemberType.ToString());
            var valueConverted = obj.ConvertFromString(value.ToString());
            property.SetValue(command, valueConverted);
        }
    }
}
