using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace SportsFinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
