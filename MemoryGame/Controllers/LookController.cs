using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemoryGame.Models;

namespace MemoryGame.Controllers
{
    public class LookController : Controller
    {
        // GET: Look

        LookContext database = new LookContext();

        protected override void Dispose(bool disposing)
        {
            database.Dispose(); 
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Buy (int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            database.Purchases.Add(purchase);
            database.SaveChanges();
            return "thnx, " + purchase.Person;
        }

        public ActionResult Index()
        {
            IEnumerable<Look> looks = database.Looks;
            ViewBag.Looks = looks;
            return View("IndexUser");
        }

    }
}