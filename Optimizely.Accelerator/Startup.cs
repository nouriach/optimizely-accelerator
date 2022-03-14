using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Optimizely.Mediator.Extensions;
using Optimizely.Web.Initialization;
using System;
using System.Reflection;

namespace Optimizely.Accelerator
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                //Add development configuration
            }

            services.AddMvc();
            services.AddCms()
                .AddCmsAspNetIdentity<ApplicationUser>();

            AddFirstRequestInitializers(services);

            services.AddProjectMediator();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/util/Login";
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
            });
        }
        private void AddFirstRequestInitializers(IServiceCollection services)
        {
            services.AddSingleton<IFirstRequestInitializer, UserInstaller>();
        }
    }
}
