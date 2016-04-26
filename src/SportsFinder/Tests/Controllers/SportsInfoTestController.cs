using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SportsFinder.Models;
using SportsFinder.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsFinder.Test.Controllers
{
    public class SportsInfoTestController : Controller
    {

        private TestDbContext _context;

        public SportsInfoTestController(TestDbContext context)
        {
           _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasketBall()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("BasketBall"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("BasketBall"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult Baseball()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("baseball"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("baseball"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult Soccer()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("soccer"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("soccer"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult Hockey()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("hockey"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("hockey"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult Cricket()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("cricket"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("cricket"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult FrisbyGolf()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("discgolf"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("discgolf"));

            }

            return View(sportEvent.ToList());
        }

        public IActionResult RockClimbing()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("rockclimbing"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("rockclimbing"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult MountainBiking()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("mountainbiking"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("mountainbiking"));

            }
            return View(sportEvent.ToList());
        }

        public IActionResult Skateboarding()
        {
            var sportEvent = from s in _context.SportEvent
                             select s;
            if (!String.IsNullOrEmpty("skateboarding"))
            {
                sportEvent = sportEvent.Where(s => s.EventSport.Contains("skateboarding"));

            }
            return View(sportEvent.ToList());
        }
    }
}