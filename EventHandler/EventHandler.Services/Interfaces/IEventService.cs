using EventHandler.DAL;
using EventHandler.DTO;
using System.Collections.Generic;

namespace EventHandler.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> GetEvents(PageOptions pageOptions);
        EventDTO GetEvent(long id);
        void CreateEvent(EventDTO eventDTO);
        void UpdateEvent(long id, EventDTO eventDTO);
        void DeleteEvent(long id);
    }
}
