using System;
using Microsoft.Owin;
using Owin;
using Refugee.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Refugee.Domain.Entities;
using Refugee.Data;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartupAttribute(typeof(Refugee.Startup))]
namespace Refugee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            RefugeeDbContext context = new RefugeeDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("SPAdmin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SPAdmin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new User();
                user.UserName = "SPAdmin";
                user.Email = "spadmin@esprit-tn.com";
                user.UserRole = "SPAdmin";
                string userPWD = "*Passw0rd";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SPAdmin");

                }
            }

            // creating Creating Member role    
            if (!roleManager.RoleExists("Member"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);
            }

            // creating Creating Volunteer role    
            if (!roleManager.RoleExists("Volunteer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Volunteer";
                roleManager.Create(role);
            }

            // creating Creating CampManager role    
            if (!roleManager.RoleExists("CampManager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "CampManager";
                roleManager.Create(role);
            }

        }
    }
}
