using System.Linq;
using Microsoft.AspNet.Mvc;
using SportsFinder.Models;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsFinder.Controllers
{
    public class FavoriteSportsController : Controller
    {
        // Dependency Injecting giving us the database context
        private ApplicationDbContext _context;

        public FavoriteSportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("In Index");
            return View(_context.Sport.ToList());
        }

        public IActionResult Edit()
        {
            return View();
        }

        public void MyMethod()
        {
            System.Diagnostics.Debug.WriteLine("My method called");
        }
    }
}
