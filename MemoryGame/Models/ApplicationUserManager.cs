using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemoryGame.Models
{
    public class ApplicationUserManager: UserManager<ApplicationUser>
    {
        public ApplicationUserManager(UserStore<ApplicationUser> store): base(store) { }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context)
        {
            ApplicationDbContext db = context.Get<ApplicationDbContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }
}