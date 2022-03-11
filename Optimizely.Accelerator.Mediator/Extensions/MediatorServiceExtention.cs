using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Optimizely.Accelerator.Services.Extensions;

namespace Optimizely.Accelerator.Mediator.Extensions
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
