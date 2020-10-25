using Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Service.ServiceJob;
using Service.Services;

namespace CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {
            services.AddTransient<IProductsService, ProductsService>();
            services.AddSingleton<JobFactory>();

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IDetailsServerService, DetailsServerService>();

            services.AddSingleton<JobFactory>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(JobFactory),
                cronExpression: "* 16 10 * * ?"));
        }
    }
}
