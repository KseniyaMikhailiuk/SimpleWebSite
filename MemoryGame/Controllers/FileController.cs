using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoryGame.Controllers
{
    public class FileController : Controller
    {
        LookContext db = new LookContext();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileFromDb = db.LookAttachmentFiles.Find(id);
            return File(fileFromDb.Content, fileFromDb.ContentType);
        }
    }
}