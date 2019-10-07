using EventHandler.DAL.Entities;
using EventHandler.DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EventHandler.DAL
{
    class EventHandlerDbContext : DbContext
    {
        private readonly Configuration _configuration;

        public EventHandlerDbContext()
        {
            _configuration = new Configuration();
        }

        DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.SqlConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Event>(new EventConfiguration());
        }
    }
}
