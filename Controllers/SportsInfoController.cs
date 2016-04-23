using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsFinder.Controllers
{
    public class SportsInfoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasketBall()
        {
            return View();
        }

        public IActionResult Baseball()
        {
            return View();
        }

        public IActionResult Soccer()
        {
            return View();
        }

        public IActionResult Hockey()
        {
            return View();
        }

        public IActionResult Cricket()
        {
            return View();
        }

        public IActionResult FrisbyGolf()
        {
            return View();
        }

        public IActionResult RockClimbing()
        {
            return View();
        }

        public IActionResult MountainBiking()
        {
            return View();
        }

        public IActionResult Skateboarding()
        {
            return View();
        }
    }
}
