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
        private const string EVENT_NULL_EXCEPTION = "event is null";

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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
            {
                throw new ArgumentNullException(EVENT_NULL_EXCEPTION);
            }

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

                //TODO: Cteate statuses table in db and relate on it
                Status = "test status"
            };

            _eventRepository.SaveEvent(eventEntity);
            _eventRepository.SaveChanges();
        }

        public void UpdateEvent(long id, EventDTO eventDTO)
        {
            var eventEntityToUpdate = _eventRepository.GetEvent(id);

            if (eventEntityToUpdate == null)
            {
                throw new ArgumentNullException(EVENT_NULL_EXCEPTION);
            }

            EventDTOToEntity(eventEntityToUpdate, eventDTO);

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
                Status = eventEntity.Status
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
            eventEntity.Status = eventDTO.Status;

            return eventEntity;
        }
    }
}
