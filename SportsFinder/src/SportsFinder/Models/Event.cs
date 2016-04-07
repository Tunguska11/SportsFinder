using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsFinder.Models
{
    public class Event
    {
        public int eventId { get; set; }
        public DateTime dateAndTime { get; set; }
        public String sportsName { get; set; }
        public Boolean tentative { get; set; }
        public Boolean fix { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int maxCount { get; set; }
        public int count { get; set; }
        public string equipmentList { get; set; }
    }
}
