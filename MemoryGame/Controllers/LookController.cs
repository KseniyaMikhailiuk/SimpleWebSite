using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MemoryGame.Models;
using System.Data.Entity.Infrastructure;

namespace MemoryGame.Controllers
{
    public class LookController : Controller
    {
        // GET: Look

        LookContext db = new LookContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose(); 
            base.Dispose(disposing);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Buy (int id)
        {
            ViewBag.LookId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return RedirectToAction("Index", "Look");
        }

        public ActionResult Index()
        {
            IEnumerable<Look> looks = db.Looks;
            ViewBag.Looks = looks;
            if (User.IsInRole("admin"))
            {
                return View("AdminIndex");
            }
            return View("Index");
        }

        public ActionResult CreateLook([Bind(Include = "Name, Price")]Look look, HttpPostedFileBase upload)
        {
            try
            {
                if(upload != null && upload.ContentLength > 0)
                {
                    var image = new LookAttachmentFile
                    {
                        ContentType = upload.ContentType,
                        FileType = FileType.Avatar,
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                    };

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        image.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    look.LookAttachmentFiles = new List<LookAttachmentFile> { image };                    
                }
                db.Looks.Add(look);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }
            return View(look);
        }


    }
}