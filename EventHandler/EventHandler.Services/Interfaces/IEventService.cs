using EventHandler.DTO;
using System.Collections.Generic;

namespace EventHandler.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<EventDTO> GetEvents();
    }
}
