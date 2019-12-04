using System;

namespace EventHandler.DTO
{
    public class EventDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Applicant { get; set; }
        public string ApplicantDepartment { get; set; }
        public DateTime? ApplyDateTime { get; set; }
        public string Responsible { get; set; }
        public string Resolver { get; set; }
        public DateTime? ResolveDateTime { get; set; }
        public string Notes { get; set; }
        public long? EventStatusId { get; set; }
        public string EventStatusName { get; set; }
    }
}
