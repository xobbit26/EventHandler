using EventHandler.DAL.Entities;
using System.Collections.Generic;

namespace EventHandler.DAL.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents(PageOptions pageOptions);
        Event GetEvent(long id);
        void SaveEvent(Event eventItem);
        void DeleteEvent(Event eventItem);
        void SaveChanges();
    }
}
