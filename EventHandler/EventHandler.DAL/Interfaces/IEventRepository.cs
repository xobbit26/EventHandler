using EventHandler.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandler.DAL.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(long id);
        void SaveEvent(Event eventItem);
        void DeleteEvent(long id);
    }
}
