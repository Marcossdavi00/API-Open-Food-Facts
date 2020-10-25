using Domain.Interfaces;
using Infra.Configuration;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IProductsRepository, BaseRepository>();
            service.AddSingleton<IConnectRepository, ConnectRepository>();
            service.AddSingleton<IDetailsServerRepository, DetailsServerRepository>();


            service.Configure<ProductsDatabaseSettings>(
             configuration.GetSection("ProductsDatabaseSettings"))
                .AddSingleton(s => s.GetService<IOptions<ProductsDatabaseSettings>>().Value);

        }
    }
}
