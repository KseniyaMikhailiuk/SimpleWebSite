using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
            ViewBag.LookId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            database.Purchases.Add(purchase);
            database.SaveChanges();
            return RedirectToAction("Index", "Look");
        }

        public ActionResult Index()
        {
            IEnumerable<Look> looks = database.Looks;
            ViewBag.Looks = looks;
            return View("Index");
        }

    }
}