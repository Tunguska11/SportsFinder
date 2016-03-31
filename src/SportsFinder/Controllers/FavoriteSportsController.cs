using System.Linq;
using Microsoft.AspNet.Mvc;
using SportsFinder.Models;
using System;
using System.Text.RegularExpressions;

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

        private IActionResult View(object p)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult MyMethod(string data)
        {
            string[] strarr = data.Split(',');
            string sportsList = "";

            for (int i = 0; i < strarr.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine(i + " " + strarr[i]);
            }

            Regex parser = new Regex(@"([a-z:A-Z:\s]+)");
            Match match = parser.Match(data);


            while (match.Success)
            {
                System.Diagnostics.Debug.WriteLine("Match Value = " + match.Value);
                sportsList += match.Value + "|";
                match = match.NextMatch();
            }

            System.Diagnostics.Debug.WriteLine("List to save = " + sportsList);


            return Json("This is my data " + data);
        }
    }
}
