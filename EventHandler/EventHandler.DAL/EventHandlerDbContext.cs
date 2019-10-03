using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHandler.DAL
{
    class EventHandlerDbContext : DbContext
    {
        DbSet<Event> Events { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5433;Database=EventHandler;Username=postgres;Password=admin");
            }
        }
    }
}
