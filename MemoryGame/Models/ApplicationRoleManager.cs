using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryGame.Models
{
    public class ApplicationRoleManager: RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store): base(store) { }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            ApplicationDbContext db = context.Get<ApplicationDbContext>();
            ApplicationRoleManager manager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            return manager;
        }
    }
}