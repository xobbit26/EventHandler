using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventStatusRepository _eventStatusRepository;

        private const string EVENT_NOT_FOUND_EXCEPTION = "event is null";
        private const string EVENT_STATUS_NOT_FOUND_EVCEPTION = "Event status with id {0} has not been found";
        private const int PENDING_EVENT_STATUS_ID = 1;

        public EventService(IEventRepository eventRepository, IEventStatusRepository eventStatusRepository)
        {
            _eventRepository = eventRepository;
            _eventStatusRepository = eventStatusRepository;
        }

        public IEnumerable<EventDTO> GetEvents()
        {
            return _eventRepository.GetEvents()
                .Select(s => MapEventEntityToDTO(s));
        }

        public EventDTO GetEvent(long id)
        {
            var eventEntity = _eventRepository.GetEvent(id);

            if (eventEntity == null)
                throw new ArgumentNullException(EVENT_NOT_FOUND_EXCEPTION);

            return MapEventEntityToDTO(eventEntity);
        }

        public void CreateEvent(EventDTO eventDTO)
        {
            var eventEntity = new Event()
            {
                Description = eventDTO.Description,
                Applicant = eventDTO.Applicant,
                ApplyDateTime = DateTime.UtcNow,
                Responsible = eventDTO.Responsible,
                EventStatusId = PENDING_EVENT_STATUS_ID
            };

            _eventRepository.SaveEvent(eventEntity);
            _eventRepository.SaveChanges();
        }

        public void UpdateEvent(long id, EventDTO eventDTO)
        {
            var eventEntityToUpdate = _eventRepository.GetEvent(id);

            if (eventEntityToUpdate == null)
                throw new ArgumentNullException(EVENT_NOT_FOUND_EXCEPTION);

            MapEventDTOToEntity(eventEntityToUpdate, eventDTO);

            var eventStatus = _eventStatusRepository.GetEventStatus(eventDTO.StatusId);
            if (eventStatus == null)
                throw new ArgumentNullException(string.Format(EVENT_STATUS_NOT_FOUND_EVCEPTION, eventDTO.StatusId));

            eventEntityToUpdate.EventStatusId = eventDTO.StatusId;
            _eventRepository.SaveChanges();
        }

        public void DeleteEvent(long id)
        {
            var eventEntityToDelete = _eventRepository.GetEvent(id);
            eventEntityToDelete.IsDeleted = true;

            _eventRepository.DeleteEvent(eventEntityToDelete);
            _eventRepository.SaveChanges();
        }

        private EventDTO MapEventEntityToDTO(Event eventEntity)
        {
            return new EventDTO()
            {
                Id = eventEntity.Id,
                Description = eventEntity.Description,
                Applicant = eventEntity.Applicant,
                ApplyDateTime = eventEntity.ApplyDateTime,
                Responsible = eventEntity.Responsible,
                Resolver = eventEntity.Resolver,
                ResolveDateTime = eventEntity.ResolveDateTime,
                Notes = eventEntity.Notes,
                StatusId = eventEntity.EventStatusId,
                StatusName = eventEntity.EventStatus.SysName
            };
        }

        private Event MapEventDTOToEntity(Event eventEntity, EventDTO eventDTO)
        {
            eventEntity.Description = eventDTO.Description;
            eventEntity.Applicant = eventDTO.Applicant;
            eventEntity.ApplyDateTime = eventDTO.ApplyDateTime;
            eventEntity.Responsible = eventDTO.Responsible;
            eventEntity.Resolver = eventDTO.Resolver;
            eventEntity.ResolveDateTime = eventDTO.ResolveDateTime;
            eventEntity.Notes = eventDTO.Notes;

            return eventEntity;
        }
    }
}
