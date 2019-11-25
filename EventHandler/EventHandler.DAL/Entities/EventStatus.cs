using System.Collections.Generic;

namespace EventHandler.DAL.Entities
{
    public class EventStatus
    {
        public long Id { get; set; }
        public string SysName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
