using Microsoft.Extensions.DependencyInjection;
using Optimizely.Interfaces;
using Optimizely.Services.Content;
using Optimizely.Services.Logging;

namespace Optimizely.Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddTransient<ILoadContentService, LoadContentService>();
            services.AddTransient<INavigationService, NavigationService>();

            services.AddTransient(typeof(IProjectLogger<>), typeof(Logger<>));
            services.AddTransient(typeof(ICorrelationIdService), typeof(CorrelationIdService));

            services.AddTransient(typeof(IUrlHelper), typeof(UrlHelper));
        }
    }
}
