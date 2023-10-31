using AutoMapper;
using AutoMapper.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Schmidt.Abstractions.Mapper.Abstractions;
using Schmidt.Abstractions.Mapper.Interfaces;
using Schmidt.Abstractions.Mapper.Models;
using System.Linq;

namespace Schmidt.Abstractions.Mapper.Helpers
{
    public static class MapperConfigurationHelper
    {
        public static void AddMapper<T>(this IServiceCollection serviceCollection)
           where T : ProfileMapper, new()
        {
            serviceCollection.Configure<MapperConfigurationExpression>(options =>
            {
                if (!options.Internal().Profiles.Any(p => p.ProfileName == typeof(T).FullName))
                    options.AddProfile<T>();
            });

            if (serviceCollection.Any(sd => sd.ServiceType == typeof(IDataMapper)))
                return;

            serviceCollection.AddSingleton<IConfigurationProvider>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<MapperConfigurationExpression>>();
                var configuration = DataMapper.CreateMapperConfiguration(options.Value);
                return configuration;
            });

            serviceCollection.Add(new ServiceDescriptor(typeof(IDataMapper),
            sp =>
            {
                var configuration = sp.GetRequiredService<IConfigurationProvider>();
                var mapper = new AutoMapper.Mapper(configuration, sp.GetService);
                return new DataMapper(mapper);
            }, ServiceLifetime.Transient));

        }
    }
}
