using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SportsFinder.Models
{
    public static class SeedSportsData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.Sport.Any())
            {
                return;   // DB has been seeded
            }

            context.Sport.AddRange(
                 new Sport
                 {
                     Name = "Basketball",
                     Type = "multiplayer",
                     EquipmentList = new List<Equipment>()
                     {
                         new Equipment
                         {
                             Name = "Basketball"
                         }
                     }
                 },
                 new Sport
                 {
                     Name = "Baseball",
                     Type = "multiplayer",
                     EquipmentList = new List<Equipment>()
                     {
                         new Equipment
                         {
                             Name = "Baseball"
                         },
                         new Equipment
                         {
                             Name = "Bats"
                         },
                         new Equipment
                         {
                             Name = "Gloves"
                         }
                     }
                 },
                 new Sport
                 {
                     Name = "Cricket",
                     Type = "multiplayer",
                     EquipmentList = new List<Equipment>()
                     {
                         new Equipment
                         {
                             Name = "ball"
                         },
                         new Equipment
                         {
                             Name = "cricket bat"
                         },
                         new Equipment
                         {
                             Name = "Stumps"
                         },
                         new Equipment
                         {
                             Name = "Gloves"
                         },
                         new Equipment
                         {

                         }
                     }
                 },
                 new Sport
                 {
                     Name = "Disc Golf",
                     Type = "solo",
                     EquipmentList = new List<Equipment>()
                     {
                         new Equipment
                         {
                             Name = "discs"
                         }
                     }
                 },
                 new Sport
                 {
                     Name = "Hockey",
                     Type = "multiplayer",
                     EquipmentList = new List<Equipment>()
                     {
                         new Equipment
                         {
                             Name = "Ball or puck"
                         },
                         new Equipment
                         {
                             Name = "Hockey Sticks"
                         }
                     }
                 },
                 new Sport
                 {
                     Name = "Mountain Biking",
                     Type = "solo"
                 },
                 new Sport
                 {
                     Name = "Rock Climbing",
                     Type = "solo"
                 },
                 new Sport
                 {
                     Name = "Skateboarding",
                     Type = "solo"
                 },
                 new Sport
                 {
                     Name = "Soccer",
                     Type = "multiplayer",
                     EquipmentList = new List<Equipment>()
                     {
                         new Equipment
                         {
                             Name = "Soccer ball"
                         },
                     }
                 }
            );

            // Save changes to database
            context.SaveChanges();
        }
    }
}
