using EventHandler.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHandler.DAL.InitialData
{
    static class EventStatusInitialData
    {
        public static void Init(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventStatus>().HasData(new EventStatus() { Id = 1, SysName = "pending", IsDeleted = false });
            modelBuilder.Entity<EventStatus>().HasData(new EventStatus() { Id = 2, SysName = "in_progress", IsDeleted = false });
            modelBuilder.Entity<EventStatus>().HasData(new EventStatus() { Id = 3, SysName = "done", IsDeleted = false });
        }
    }
}
