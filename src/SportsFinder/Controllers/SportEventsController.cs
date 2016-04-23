using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SportsFinder.Models;
using System.Text.RegularExpressions;

namespace SportsFinder.Controllers
{
    public class SportEventsController : Controller
    {
        private ApplicationDbContext _context;
        
        public SportEventsController(ApplicationDbContext context)
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
                }else
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
        public IActionResult UpdateEquipmentList(string equipList)
        {
            //string[] strarr = equipList.Split(',');
            string sportsList = "";

            System.Diagnostics.Debug.WriteLine("Value = " + equipList);

            //Regex parser = new Regex(@"([a-z:A-Z:\s]+)");
            //Match match = parser.Match(equipList);


            //while (match.Success)
            //{
            //    System.Diagnostics.Debug.WriteLine("Match Value = " + match.Value);
            //    sportsList += match.Value + "|";
            //    match = match.NextMatch();
            //}

            return Json("Updated equipment for event!"); ;
        }
    }
    

}

