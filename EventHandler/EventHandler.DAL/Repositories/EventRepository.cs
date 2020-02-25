using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using EventHandler.DAL.Extentions;
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

        public IEnumerable<Event> GetEvents(PageOptions pageOptions)
        {
            IQueryable<Event> query = _dbContext.Events
                .Include(s => s.EventStatus)
                .Where(s => !s.IsDeleted)
                .AsQueryable();

            query = pageOptions.IsSortable
                    ? query.OrderBy(pageOptions.SortBy, pageOptions.Direction == SortDirection.Ascending)
                    : query.OrderBy(s => s.ApplyDateTime);

            if (pageOptions.IsPageable)
                query = query.Skip(pageOptions.Skip).Take(pageOptions.Take);

            return query
                .AsNoTracking()
                .AsEnumerable();
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

        public long GetEventsCount()
        {
            return _dbContext.Events
                .Where(x => !x.IsDeleted)
                .Count();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
