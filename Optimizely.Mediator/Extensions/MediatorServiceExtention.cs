using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Optimizely.Services.Extensions;

namespace Optimizely.Mediator.Extensions
{
    public static class MediatorServiceExtention
    {
        public static void AddProjectMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(MediatorServiceExtention)));
            services.AddProjectServices();
        }
    }
}
