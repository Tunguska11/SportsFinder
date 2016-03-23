using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SportsFinder.Models;

namespace SportsFinder.Controllers
{
    public class SportsController : Controller
    {
        private ApplicationDbContext _context;

        public SportsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Sports
        public IActionResult Index()
        {
            return View(_context.Sport.ToList());
        }

        // GET: Sports/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sport sport = _context.Sport.Single(m => m.ID == id);
            if (sport == null)
            {
                return HttpNotFound();
            }

            return View(sport);
        }

        // GET: Sports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _context.Sport.Add(sport);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        // GET: Sports/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sport sport = _context.Sport.Single(m => m.ID == id);
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        // POST: Sports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sport);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        // GET: Sports/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sport sport = _context.Sport.Single(m => m.ID == id);
            if (sport == null)
            {
                return HttpNotFound();
            }

            return View(sport);
        }

        // POST: Sports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Sport sport = _context.Sport.Single(m => m.ID == id);
            _context.Sport.Remove(sport);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
