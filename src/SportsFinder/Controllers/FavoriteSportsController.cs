using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SportsFinder.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsFinder.Controllers
{
    public class FavoriteSportsController : Controller
    {
        private ApplicationDbContext _context;

        public FavoriteSportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Sport.ToList());
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
