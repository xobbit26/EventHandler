using EventHandler.DAL.Entities;

namespace EventHandler.DAL.Interfaces
{
    public interface IEventStatusRepository
    {
        EventStatus GetEventStatus(long id);
    }
}
