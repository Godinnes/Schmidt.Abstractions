using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Schmidt.Abstractions.Cosmos.Configurations
{
    public static class CosmosHelper
    {
        public static void AddCosmosDB(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton((serviceProvider) =>
            {
                var connectionString = configuration["Cosmos:ConnetionString"];
                return new CosmosClient(connectionString);
            });
        }
    }
}
