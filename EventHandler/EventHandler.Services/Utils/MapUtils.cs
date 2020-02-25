using EventHandler.DAL.Entities;
using EventHandler.DTO;

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
    }
}
