using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SportsFinder.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public string[] SportsList { get; set; }
        public string City { get; set; }

        // collection of sports for favorites
        public string FavoriteSports { get; set; }
    }
}
