using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SportsFinder.Models;
using System.Text.RegularExpressions;
using SportsFinder.Data;

namespace SportsFinder.Controllers
{
    public class SportEventsTestController : Controller
    {
        private TestDbContext _context;

        public SportEventsTestController(TestDbContext context)
        {
            _context = context;
        }

        // GET: SportEvents
        public IActionResult Index()
        {
            return View(_context.SportEvent.ToList());
        }

        // GET: SportEvents/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SportEvent sportEvent = _context.SportEvent.FirstOrDefault(m => m.ID == id);
            if (sportEvent == null)
            {
                return null;
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
            string[] arr = sportEvent.EquipmentList.Split(',');
            string newEqpList = "";
            for (int k = 0; k < arr.Length; k++)
            {
                string newStr = "";
                char[] charArr = arr[k].ToCharArray();
                if (charArr[0] == ' ')
                {
                    for (int i = 1; i < charArr.Length; i++)
                    {
                        newStr += charArr[i];
                    }
                    newEqpList += newStr;
                }
                else
                {
                    newEqpList += arr[k];
                }

                if (k != (arr.Length - 1))
                    newEqpList += ",";
            }

            sportEvent.EquipmentList = newEqpList;

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

        [HttpPost]
        public IActionResult UpdateEquipmentList(string data, int eventId)
        {
            string broughtEquipmentList = "";

            System.Diagnostics.Debug.WriteLine("Value = " + data);

            Regex parser = new Regex(@"([a-z:A-z\s+]+):([a-z:A-Z]+@[a-z:A-Z]+\.[a-z:A-Z]+)");
            Match match = parser.Match(data);

            while (match.Success)
            {
                broughtEquipmentList += match.Value + "|";
                match = match.NextMatch();
            }

            SportEvent sportEvent = _context.SportEvent.Single(m => m.ID == eventId);
            sportEvent.EquipmentBeingBroughtList = broughtEquipmentList;
            _context.SaveChanges();

            return Json("This equipment is now marked as being brought by you!");
        }

        [HttpPost]
        public IActionResult AddUserToRsvpList(string userName, int eventId)
        {
            SportEvent sportEvent = _context.SportEvent.Single(m => m.ID == eventId);
            string currentRsvpList = "";

            if (sportEvent.RSVPList != null)
            {
                currentRsvpList += sportEvent.RSVPList;
            }

            currentRsvpList += userName + "|";

            sportEvent.RSVPList = currentRsvpList;
            sportEvent.PplAttendingCount++;
            _context.SaveChanges();

            return Json(userName + " you have been added to the RSVP list!");
        }
    }
}

