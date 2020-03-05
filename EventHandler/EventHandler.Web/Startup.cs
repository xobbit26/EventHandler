using EventHandler.DAL;
using EventHandler.DAL.Interfaces;
using EventHandler.DAL.Repositories;
using EventHandler.Services;
using EventHandler.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventHandler.Web
{
    public class Startup
    {
        private const string _eventHandlerUIOrigin = "eventHandlerUIOrigin";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DIConfiguration(services);
            CorsConfiguration(services);
            DBConfiguration(services);
            LoggingConfiguration(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"env.EnvironmentName: {env.EnvironmentName}");
            logger.LogInformation($"connectionString: {Configuration.GetConnectionString("DataConnection")}");

            if (env.IsDevelopment() || env.EnvironmentName == "DevelopmentAlternateSQLConnection")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(_eventHandlerUIOrigin);
            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void DIConfiguration(IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventStatusRepository, EventStatusRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceService, ResourceService>();
        }

        private void CorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(_eventHandlerUIOrigin,
                    builder =>
                    {
                        builder.WithOrigins(Configuration.GetSection("URL").GetSection("EventHandlerUI").Value)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }

        private void DBConfiguration(IServiceCollection services)
        {
            services.AddDbContext<EventHandlerDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DataConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(EventHandlerDbContext).Assembly.FullName));
            });
        }

        private void LoggingConfiguration(IServiceCollection services)
        {
            services.AddLogging(lc =>
            {
                lc.AddConsole();
                lc.AddFile(Configuration.GetSection("Logging").GetSection("FilePath").Value);
            });
        }
    }
}
