using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsFinder.Models
{
    public class Sport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ICollection<Equipment> EquipmentList { get; set; }
    }
}
