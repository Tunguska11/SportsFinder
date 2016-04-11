using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SportsFinder.Models;

namespace SportsFinder.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.SportEvent.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "SportsFinder is dedicated to helping you find fellow sports enthusiasts near you, letting find an event in your neighbourhood when you're in the mood for sport.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Created by James Stell, Thomas Neil K, Hardik Thakkar & Gabriel Stevens";

            return View();
        }


        public IActionResult UserProfile()
        {
            ViewData["Message"] = "Created by James Stell, Thomas Neil K, Hardik Thakkar & Gabriel Stevens";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
