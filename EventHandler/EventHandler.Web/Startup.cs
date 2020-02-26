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

            services.AddLogging();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogDebug($"env.EnvironmentName: {env.EnvironmentName}");
            logger.LogDebug($"connectionString: {Configuration.GetConnectionString("DataConnection")}");

            if (env.IsDevelopment() || env.EnvironmentName == "DevelopmentAlternateSQLConnection")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(_eventHandlerUIOrigin);
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
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
                options.UseNpgsql("Host=localhost;Port=5433;Database=EventHandlerData;Username=postgres;Password=admin",
                    //Configuration.GetConnectionString("DataConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(EventHandlerDbContext).Assembly.FullName));
            });
        }
    }
}
