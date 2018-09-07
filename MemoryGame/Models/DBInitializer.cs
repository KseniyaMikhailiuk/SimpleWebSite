using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;

namespace MemoryGame.Models
{
    public class DBInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    { 
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var admin = new ApplicationRole();
            admin.Name = "admin";
            var user = new ApplicationRole();
            user.Name = "user";

            roleManager.Create(admin);
            roleManager.Create(user);

            ApplicationUser adminAppUser = new ApplicationUser { Email = "mikhailiuk.k@gmail.com", UserName = "mikhailiuk.k@gmail.com",
                    CreationDate = DateTime.Now};
            var result = userManager.Create(adminAppUser, "123456789");

            if (result.Succeeded)
            {
                userManager.AddToRole(adminAppUser.Id, admin.Name);
                userManager.AddToRole(adminAppUser.Id, admin.Name);
            }
            base.Seed(context);
        }
    }
}