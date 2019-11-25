using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventHandlerDbContext _dbContext;

        public EventRepository(EventHandlerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _dbContext.Events
                .Include(s => s.EventStatus)
                .OrderBy(s => s.ApplyDateTime)
                .Where(s => !s.IsDeleted);
        }

        public Event GetEvent(long id)
        {
            return _dbContext.Events
                .Include(s => s.EventStatus)
                .Where(s => !s.IsDeleted)
                .FirstOrDefault(s => s.Id == id);
        }

        public void SaveEvent(Event eventItem)
        {
            _dbContext.Events.Add(eventItem);
        }

        public void DeleteEvent(Event eventItem)
        {
            _dbContext.Events.Remove(eventItem);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
