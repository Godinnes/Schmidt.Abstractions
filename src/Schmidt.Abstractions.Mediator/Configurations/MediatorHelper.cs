using Microsoft.Extensions.DependencyInjection;
using Schmidt.Abstractions.Mediator.Abstractions;
using Schmidt.Abstractions.Mediator.Services;
using System;
using System.Linq;

namespace Schmidt.Abstractions.Mediator.Configurations
{
    public static class MediatorHelper
    {
        public static void AddMediator(this IServiceCollection serviceCollection, params Type[] commandTypes)
        {
            var assemblies = commandTypes.Select(a => a.Assembly).ToArray();
            serviceCollection.AddMediatR(a => a.RegisterServicesFromAssemblies(assemblies));
            serviceCollection.AddSingleton<IMediatorService, MediatorService>();
        }
    }
}
