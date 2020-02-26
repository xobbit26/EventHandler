using EventHandler.DAL.Entities;
using EventHandler.DAL.EntitiesConfigurations;
using EventHandler.DAL.InitialData;
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
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Event>(new EventConfiguration());
            modelBuilder.ApplyConfiguration<EventStatus>(new EventStatusConfiguration());
            modelBuilder.ApplyConfiguration<Resource>(new ResourceConfiguration());

            AddInitialData(modelBuilder);
        }

        private void AddInitialData(ModelBuilder modelBuilder)
        {
            EventStatusInitialData.Init(modelBuilder);
            ResourceInitialData.Init(modelBuilder);
        }
    }
}
