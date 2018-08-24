using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoryGame.Controllers
{
    public class GameController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}