using EventHandler.DAL.Entities;
using System.Collections.Generic;

namespace EventHandler.DAL.Interfaces
{
    public interface IEventStatusRepository
    {
        IEnumerable<EventStatus> GetEventStatuses();
        EventStatus GetEventStatusBySysName(string sysName);
        void SaveEventStatus(EventStatus eventStatus);
        void SaveChanges();
    }
}
