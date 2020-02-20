using EventHandler.DAL;
using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.DTO.Grid;
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

        private const string EVENT_NOT_FOUND_EXCEPTION = "Event is null";
        private const string EVENT_STATUS_NOT_FOUND_EVCEPTION = "Event status with id {0} has not been found";
        private const string EVENT_NOT_SPECIFIED_EXCEPTION = "EventStatusId hasn't been specified";
        private const long PENDING_EVENT_STATUS_ID = 1;

        public EventService(IEventRepository eventRepository, IEventStatusRepository eventStatusRepository)
        {
            _eventRepository = eventRepository;
            _eventStatusRepository = eventStatusRepository;
        }

        public IEnumerable<EventDTO> GetEvents(PageOptions pageOptions)
        {
            return _eventRepository.GetEvents(pageOptions)
                .Select(s => GetEventDTOFromEventEntity(s));
        }

        public GridDTO<EventDTO> GetEventsGridData(PageOptions pageOptions)
        {
            throw new NotImplementedException();
        }

        public EventDTO GetEvent(long id)
        {
            var eventEntity = _eventRepository.GetEvent(id);

            if (eventEntity == null)
                throw new ArgumentNullException(EVENT_NOT_FOUND_EXCEPTION);

            return GetEventDTOFromEventEntity(eventEntity);
        }

        public void CreateEvent(EventDTO eventDTO)
        {
            var eventEntity = new Event();
            MapEventDTOToEntity(eventDTO, eventEntity);

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

            MapEventDTOToEntity(eventDTO, eventEntityToUpdate);

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

        private EventDTO GetEventDTOFromEventEntity(Event eventEntity)
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
                EventStatusId = eventEntity.EventStatusId,
                EventStatusName = eventEntity.EventStatus.SysName
            };
        }

        private void MapEventDTOToEntity(EventDTO eventDTO, Event eventEntity)
        {
            eventEntity.Description = eventDTO.Description;
            eventEntity.Applicant = eventDTO.Applicant;
            eventEntity.ApplicantDepartment = eventDTO.ApplicantDepartment;
            eventEntity.ApplyDateTime = eventDTO.ApplyDateTime ?? DateTime.UtcNow;
            eventEntity.Responsible = eventDTO.Responsible;
            eventEntity.Resolver = eventDTO.Resolver;
            eventEntity.ResolveDateTime = eventDTO.ResolveDateTime;
            eventEntity.Notes = eventDTO.Notes;
            eventEntity.EventStatusId = eventDTO.EventStatusId ?? PENDING_EVENT_STATUS_ID;
        }
    }
}
