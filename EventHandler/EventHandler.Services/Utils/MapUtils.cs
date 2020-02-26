using EventHandler.DAL.Entities;
using EventHandler.DTO;
using EventHandler.DTO.Enums;
using System;

namespace EventHandler.Services.Utils
{
    internal static class MapUtils
    {
        internal static EventDTO GetEventDTOFromEventEntity(Event eventEntity)
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

        internal static void MapEventDTOToEntity(EventDTO eventDTO, Event eventEntity)
        {
            eventEntity.Description = eventDTO.Description;
            eventEntity.Applicant = eventDTO.Applicant;
            eventEntity.ApplicantDepartment = eventDTO.ApplicantDepartment;
            eventEntity.ApplyDateTime = eventDTO.ApplyDateTime ?? DateTime.UtcNow;
            eventEntity.Responsible = eventDTO.Responsible;
            eventEntity.Resolver = eventDTO.Resolver;
            eventEntity.ResolveDateTime = eventDTO.ResolveDateTime;
            eventEntity.Notes = eventDTO.Notes;
            eventEntity.EventStatusId = eventDTO.EventStatusId ?? (int)EventStatusEnum.Pending;
        }
    }
}
