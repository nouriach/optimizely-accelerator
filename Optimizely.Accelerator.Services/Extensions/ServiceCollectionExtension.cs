using Microsoft.Extensions.DependencyInjection;
using Optimizely.Accelerator.Interfaces;
using Optimizely.Accelerator.Services.Logging;

namespace Optimizely.Accelerator.Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddTransient<ILoadContentService, LoadContentService>();
            services.AddTransient<INavigationService, NavigationService>();

            services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
            services.AddTransient(typeof(ICorrelationIdService), typeof(CorrelationIdService));
        }
    }
}
