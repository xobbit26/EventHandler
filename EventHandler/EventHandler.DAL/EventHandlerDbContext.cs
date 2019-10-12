using EventHandler.DAL.Entities;
using EventHandler.DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EventHandler.DAL
{
    public class EventHandlerDbContext : DbContext
    {
        public EventHandlerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Event>(new EventConfiguration());
        }
    }
}
