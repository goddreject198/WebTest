using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using WebAppLearning.Models;

[assembly: OwinStartupAttribute(typeof(WebAppLearning.Startup))]
namespace WebAppLearning
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";

                var check = userManager.Create(user, "Admin*2019");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
                else
                {
                    var e = new Exception("Could not add default User");
                    var enumerator = check.Errors.GetEnumerator();
                    foreach (var error in check.Errors)
                    {
                        e.Data.Add(enumerator.Current, error);
                    }
                    throw e;
                }
            }

        }
    }
}
