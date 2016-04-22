using System.Linq;
using Microsoft.AspNet.Mvc;
using SportsFinder.Models;
using System;
using System.Text.RegularExpressions;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsFinder.Controllers
{
    public class FavoriteSportsController : Controller
    {
        // Dependency Injecting giving us the database context
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public FavoriteSportsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("In Index");
            ViewData["User"] = _context.Users.First(u => u.Id == User.GetUserId());
            return View(_context.Sport.ToList());
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveFavoriteSports(string data)
        {
            string[] strarr = data.Split(',');
            string sportsList = "";

            for (int i = 0; i < strarr.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine(i + " " + strarr[i]);
            }

            Regex parser = new Regex(@"([a-z:A-Z:\s]+)");
            Match match = parser.Match(data);


            while (match.Success)
            {
                System.Diagnostics.Debug.WriteLine("Match Value = " + match.Value);
                sportsList += match.Value + "|";
                match = match.NextMatch();
            }

            System.Diagnostics.Debug.WriteLine("List to save = " + sportsList);

            ApplicationUser user = _context.Users.First(u => u.Id == User.GetUserId());
            user.FavoriteSports = sportsList;
            _context.Update(user);
            _context.SaveChanges();

            return Json("Favorite Sports Saved!");
        }
    }
}
