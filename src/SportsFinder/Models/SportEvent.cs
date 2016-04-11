using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsFinder.Models
{
    public class SportEvent
    {
        public int ID { get; set; }
        public DateTime EventTime { get; set; }
        public string EventSport { get; set; }
        public bool IsTentative { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int PplAttendingCount { get; set; }
        public int MaxPeopleAllowed { get; set; }
        public string EquipmentList { get; set; }
    }
}
