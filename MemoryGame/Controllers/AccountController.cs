using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MemoryGame.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MemoryGame.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login (LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                if (user != null)
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password or login");
                }
            }
            ViewBag.returnurl = returnUrl;
            return View(model);
        }


        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, Address = model.Address, UserName = model.Email,
                                        CreationDate = DateTime.Now};
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "user");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }
    }
}