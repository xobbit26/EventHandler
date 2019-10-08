using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventHandler.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventHandler.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuring db context
            services.AddDbContext<EventHandlerDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DataConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(EventHandlerDbContext).Assembly.FullName));
            });
            services.AddLogging();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogDebug($"env.EnvironmentName: {env.EnvironmentName}");
            logger.LogDebug($"connectionString: {Configuration.GetConnectionString("DataConnection")}");

            if (env.IsDevelopment()
                || env.EnvironmentName == "DevelopmentAlternateSQLConnection")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
