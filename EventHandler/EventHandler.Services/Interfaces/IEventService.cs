using EventHandler.DAL;
using EventHandler.DTO;
using EventHandler.DTO.Grid;
using System.Collections.Generic;

namespace EventHandler.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> GetEvents(PageOptions pageOptions);
        GridDTO<EventDTO> GetGridData(PageOptions pageOptions, string locale);
        EventDTO GetEvent(long id);
        void CreateEvent(EventDTO eventDTO);
        void UpdateEvent(long id, EventDTO eventDTO);
        void DeleteEvent(long id);
    }
}
