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
                .Include(x => x.EventStatus)
                .Where(x => !x.IsDeleted);
        }

        public Event GetEvent(long id)
        {
            return _dbContext.Events
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public void SaveEvent(Event eventItem)
        {
            _dbContext.Events.Add(eventItem);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
