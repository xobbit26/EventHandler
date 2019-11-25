using System;

namespace EventHandler.DAL.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Applicant { get; set; }
        public DateTime ApplyDateTime { get; set; }
        public string Responsible { get; set; }
        public string Resolver { get; set; }
        public DateTime? ResolveDateTime { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
