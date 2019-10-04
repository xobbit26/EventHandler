using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandler.DAL.Repositories
{
    class EventRepository : IEventRepository
    {
        public void DeleteEvent(long id)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(Event eventItem)
        {
            throw new NotImplementedException();
        }
    }
}
