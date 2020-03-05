using System;
using EventHandler.DAL;
using EventHandler.DTO;
using EventHandler.DTO.Grid;
using EventHandler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventHandler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventService _eventService;

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            _eventService = eventService;
            _logger = logger;
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
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public void Post([FromBody] EventDTO eventDTO)
        {
            try
            {
                _eventService.CreateEvent(eventDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
