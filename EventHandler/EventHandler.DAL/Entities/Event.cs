using System;
using System.Collections.Generic;
using System.Text;

namespace EventHandler.DAL.Entities
{
    public class Event
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
