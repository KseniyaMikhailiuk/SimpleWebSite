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


//            database.Looks.Add(new Look { Name = "Look1", Brand = "Zara", Price = 150, Style = "casual" });
//            database.Looks.Add(new Look { Name = "Look2", Brand = "Zara", Price = 150, Style = "sport" });
//            database.Looks.Add(new Look { Name = "Look3", Brand = "Zara", Price = 150, Style = "casual" });
//            database.Looks.Add(new Look { Name = "Look4", Brand = "Zara", Price = 150, Style = "official" });
//            database.Looks.Add(new Look { Name = "Look1", Brand = "Zara", Price = 150, Style = "official" });
//            database.Looks.Add(new Look { Name = "Look5", Brand = "Zara", Price = 150, Style = "casual" });
            base.Seed(context);
        }
    }
}