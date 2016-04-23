using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SportsFinder.Models;
using System.Security.Claims;
using System;
using System.Collections.Generic;

namespace SportsFinder.Controllers
{
    public class SportEventsController : Controller
    {
        private ApplicationDbContext _context;

        public object ToLi { get; private set; }

        public SportEventsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SportEvents
        public IActionResult Index()
        {

            return View(_context.SportEvent.ToList());
        }

        private void ToList()
        {
            throw new NotImplementedException();
        }

        // GET: SportEvents/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SportEvent sportEvent = _context.SportEvent.Single(m => m.ID == id);
             if (sportEvent == null)
            {
                return HttpNotFound();
            }

            return View(sportEvent);
        }

        

        // GET: SportEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportEvents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SportEvent sportEvent)
        {
            if (ModelState.IsValid)
            {
                _context.SportEvent.Add(sportEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportEvent);
        }

        // GET: SportEvents/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SportEvent sportEvent = _context.SportEvent.Single(m => m.ID == id);
            if (sportEvent == null)
            {
                return HttpNotFound();
            }
            return View(sportEvent);
        }

        // POST: SportEvents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SportEvent sportEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sportEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportEvent);
        }

        // GET: SportEvents/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SportEvent sportEvent = _context.SportEvent.Single(m => m.ID == id);
            if (sportEvent == null)
            {
                return HttpNotFound();
            }

            return View(sportEvent);
        }

        // POST: SportEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            SportEvent sportEvent = _context.SportEvent.Single(m => m.ID == id);
            _context.SportEvent.Remove(sportEvent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
