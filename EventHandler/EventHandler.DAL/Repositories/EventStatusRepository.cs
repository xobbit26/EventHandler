using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using System.Linq;

namespace EventHandler.DAL.Repositories
{
    public class EventStatusRepository : IEventStatusRepository
    {
        private readonly EventHandlerDbContext _dbContext;

        public EventStatusRepository(EventHandlerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EventStatus GetEventStatus(long id)
        {
            return _dbContext.EventStatuses
                .Where(s => !s.IsDeleted)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
