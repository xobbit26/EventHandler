using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                .Where(s => !s.IsDeleted);
        }

        public Event GetEvent(long id)
        {
            return _dbContext.Events
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
