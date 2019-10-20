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

        private const string EVENT_NULL_EXCEPTION = "event is null";
        private const string PENDING_EVENTSTATUS_SYSNAME = "pending";

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
                throw new ArgumentNullException(EVENT_NULL_EXCEPTION);

            return MapEventEntityToDTO(eventEntity);
        }

        public void CreateEvent(EventDTO eventDTO)
        {
            EventStatus pendingEventStatus = _eventStatusRepository
                .GetEventStatusBySysName(PENDING_EVENTSTATUS_SYSNAME);

            var eventEntity = new Event()
            {
                Description = eventDTO.Description,
                Applicant = eventDTO.Applicant,
                ApplyDateTime = DateTime.UtcNow,
                Responsible = eventDTO.Responsible,
                EventStatus = pendingEventStatus
            };

            _eventRepository.SaveEvent(eventEntity);
            _eventRepository.SaveChanges();
        }

        public void UpdateEvent(long id, EventDTO eventDTO)
        {
            var eventEntityToUpdate = _eventRepository.GetEvent(id);

            if (eventEntityToUpdate == null)
                throw new ArgumentNullException(EVENT_NULL_EXCEPTION);

            EventDTOToEntity(eventEntityToUpdate, eventDTO);

            _eventRepository.SaveChanges();
        }

        public void DeleteEvent(long id)
        {
            var eventEntityToDelete = _eventRepository.GetEvent(id);
            eventEntityToDelete.IsDeleted = true;

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

                //TODO: Create Resource table for retrieving name of event depends on language
                EventStatus = eventEntity.EventStatus.SysName
            };
        }

        private Event EventDTOToEntity(Event eventEntity, EventDTO eventDTO)
        {
            eventEntity.Id = eventDTO.Id;
            eventEntity.Description = eventDTO.Description;
            eventEntity.Applicant = eventDTO.Applicant;
            eventEntity.ApplyDateTime = eventDTO.ApplyDateTime;
            eventEntity.Responsible = eventDTO.Responsible;
            eventEntity.Resolver = eventDTO.Resolver;
            eventEntity.ResolveDateTime = eventDTO.ResolveDateTime;
            eventEntity.Notes = eventDTO.Notes;
            eventEntity.EventStatusId = eventDTO.EventStatusId;

            return eventEntity;
        }
    }
}
