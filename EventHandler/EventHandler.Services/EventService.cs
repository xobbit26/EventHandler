using EventHandler.DAL;
using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.DTO.Grid;
using EventHandler.Services.Interfaces;
using EventHandler.Services.Processors;
using EventHandler.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventStatusRepository _eventStatusRepository;
        private IResourceService _resourceService;

        
        private const string EVENT_NOT_FOUND_EXCEPTION = "Event is null";
        private const string EVENT_STATUS_NOT_FOUND_EVCEPTION = "Event status with id {0} has not been found";
        private const string EVENT_NOT_SPECIFIED_EXCEPTION = "EventStatusId hasn't been specified";

        public EventService(IEventRepository eventRepository,
            IEventStatusRepository eventStatusRepository,
            IResourceService resourceService)
        {
            _eventRepository = eventRepository;
            _eventStatusRepository = eventStatusRepository;
            _resourceService = resourceService;
        }

        public IEnumerable<EventDTO> GetEvents(PageOptions pageOptions)
        {
            return _eventRepository.GetEvents(pageOptions)
                .Select(s => MapUtils.GetEventDTOFromEventEntity(s));
        }

        public GridDTO<EventDTO> GetGridData(PageOptions pageOptions, string locale)
        {
            var eventGridDataProcessor = new EventGridDataProcessor(_eventRepository, _resourceService, locale);
            return eventGridDataProcessor.GetGridData(pageOptions);
        }

        public EventDTO GetEvent(long id)
        {
            var eventEntity = _eventRepository.GetEvent(id);

            if (eventEntity == null)
                throw new ArgumentNullException(EVENT_NOT_FOUND_EXCEPTION);

            return MapUtils.GetEventDTOFromEventEntity(eventEntity);
        }

        public void CreateEvent(EventDTO eventDTO)
        {
            var eventEntity = new Event();
            MapUtils.MapEventDTOToEntity(eventDTO, eventEntity);

            _eventRepository.SaveEvent(eventEntity);
            _eventRepository.SaveChanges();
        }

        public void UpdateEvent(long id, EventDTO eventDTO)
        {
            var eventEntityToUpdate = _eventRepository.GetEvent(id);

            if (eventEntityToUpdate == null)
                throw new ArgumentNullException(EVENT_NOT_FOUND_EXCEPTION);

            if (!eventDTO.EventStatusId.HasValue)
                throw new ArgumentNullException(EVENT_NOT_SPECIFIED_EXCEPTION);

            MapUtils.MapEventDTOToEntity(eventDTO, eventEntityToUpdate);

            var eventStatus = _eventStatusRepository.GetEventStatus(eventEntityToUpdate.EventStatusId);
            if (eventStatus == null)
                throw new ArgumentNullException(string.Format(EVENT_STATUS_NOT_FOUND_EVCEPTION, eventDTO.EventStatusId));

            _eventRepository.SaveChanges();
        }

        public void DeleteEvent(long id)
        {
            var eventEntityToDelete = _eventRepository.GetEvent(id);
            eventEntityToDelete.IsDeleted = true;

            _eventRepository.DeleteEvent(eventEntityToDelete);
            _eventRepository.SaveChanges();
        }
    }
}
