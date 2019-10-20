using EventHandler.DAL.Entities;
using System.Collections.Generic;

namespace EventHandler.DAL.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(long id);
        void SaveEvent(Event eventItem);
        void SaveChanges();
    }
}
