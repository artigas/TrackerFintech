using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackerFintech.DataContexts;

namespace TrackerFintech
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FeatureToggles>(x => new FeatureToggles()
            {
                DeveloperExceptions = configuration.GetValue<bool>("FeatureToggles:DeveloperExceptions")
            });

            services.AddDbContext<TrackerDataContext>(options =>
            {
                var connectiontString = configuration.GetConnectionString("TrackerDataContext");
                options.UseSqlServer(connectiontString);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FeatureToggles features)
        {
            //if (env.IsDevelopment())
            //if (configuration.GetValue<bool>("EnableDevExceptions")) // Se parsea el valor seteado en TrackerFintech -> Properties -> Debug
            if (features.DeveloperExceptions) // Valor seteado en appsettings o appsettings.Development
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "Default",
                    "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseFileServer();
        }
    }
}
