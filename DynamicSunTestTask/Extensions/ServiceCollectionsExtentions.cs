using DynamicSunTestTask.CrudServices;

namespace DynamicSunTestTask.Extensions
{
    public static class ServiceCollectionsExtentions
    {
        public static IServiceCollection AddCategoryCrudServices(this IServiceCollection services)
        {
            services.AddTransient<WheatherColumnsCrud>();
            services.AddTransient<ReadDocument>();

            return services;
        }
    }
}