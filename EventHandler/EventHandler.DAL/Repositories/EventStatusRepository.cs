using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using System;
using System.Collections.Generic;
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

        public IEnumerable<EventStatus> GetEventStatuses()
        {
            return _dbContext.EventStatuses
                .Where(x => !x.IsDeleted);
        }

        public EventStatus GetEventStatusBySysName(string sysName)
        {
            return _dbContext.EventStatuses
                   .FirstOrDefault(x => !x.IsDeleted && x.SysName == sysName);
        }

        public void SaveEventStatus(EventStatus eventStatus)
        {
            _dbContext.EventStatuses.Add(eventStatus);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
