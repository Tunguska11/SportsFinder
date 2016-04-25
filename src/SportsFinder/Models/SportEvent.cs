using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsFinder.Models
{
    public class SportEvent
    {
        public int ID { get; set; }

        [Display(Name = "Event Time")]
        public DateTime EventTime { get; set; }

        [Display(Name = "Event Sport")]
        public string EventSport { get; set; }

        [Display(Name = "Tentative Event")]
        public bool IsTentative { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [Display(Name = "Num People Attending")]
        public int PplAttendingCount { get; set; }

        [Display(Name = "Max People Allowed")]
        public int MaxPeopleAllowed { get; set; }

        [Display(Name = "Equipment List")]
        public string EquipmentList { get; set; }

        // will contain the piece of equipment being brought with the username
        // of who is bringing it -> "harness:brad@gmail.com|shoes:hardik@gmail.com|"
        public string EquipmentBeingBroughtList { get; set; }

        public string Address { get; set; }

        [Display(Name = "List of Participants")]
        public string RSVPList { get; set; }
    }
}
