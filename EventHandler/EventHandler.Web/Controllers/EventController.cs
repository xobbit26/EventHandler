using System;
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
        [Route("grid-data/{locale}")]
        public GridDTO<EventDTO> GetGridData([FromQuery] PageOptions pageOptions, string locale)
        {
            try
            {
                return _eventService.GetGridData(pageOptions, locale);
            }
            catch (Exception ex)
            {
                //TODO: add logging
                throw ex;
            }
        }

        [HttpPost]
        public void Post([FromBody] EventDTO eventDTO)
        {
            _eventService.CreateEvent(eventDTO);
        }
    }
}
