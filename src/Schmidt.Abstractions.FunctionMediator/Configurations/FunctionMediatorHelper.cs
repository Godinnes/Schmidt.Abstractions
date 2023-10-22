using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using Schmidt.Abstractions.FunctionMediator.Abstractions;
using Schmidt.Abstractions.FunctionMediator.Services;

namespace Schmidt.Abstractions.FunctionMediator.Configurations
{
    public static class FunctionMediatorHelper
    {
        public static void AddMediator(this IServiceCollection serviceCollection, params Type[] commandTypes)
        {
            var assemblies = commandTypes.Select(a => a.Assembly).ToArray();
            serviceCollection.AddMediatR(a => a.RegisterServicesFromAssemblies(assemblies));
            serviceCollection.AddSingleton<IFunctionMediatorService, FunctionMediatorService>();
        }
    }
}
