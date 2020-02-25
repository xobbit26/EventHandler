using System.Collections.Generic;
using System.Linq;
using EventHandler.DAL;
using EventHandler.DTO;
using EventHandler.DTO.Grid;
using EventHandler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventHandler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IEnumerable<EventDTO> Get([FromQuery] PageOptions pageOptions)
        {
            return _eventService.GetEvents(pageOptions);
        }

        [HttpGet]
        [Route("grid-data")]
        public GridDTO<EventDTO> GetGridData([FromQuery] PageOptions pageOptions)
        {
            return _eventService.GetGridData(pageOptions);
        }

        [HttpGet("{id}", Name = "Get")]
        public EventDTO Get(long id)
        {
            return _eventService.GetEvent(id);
        }

        [HttpPost]
        public void Post([FromBody] EventDTO eventDTO)
        {
            _eventService.CreateEvent(eventDTO);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] EventDTO eventDTO)
        {
            _eventService.UpdateEvent(id, eventDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _eventService.DeleteEvent(id);
        }
    }
}
