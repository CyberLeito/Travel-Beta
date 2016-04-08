using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel_Beta.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Travel_Beta.Logic
{
    public class RoleActions
    {
        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            //IdentityResult IdRoleResult;
            //IdentityResult IdUserResult; 

             // Create a RoleStore object by using the ApplicationDbContext object. 
             // The RoleStore is only allowed to contain IdentityRole objects.
             var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 

            //var roleMgr = new RoleManager<IdentityRole>(roleStore);

            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));






            //roleMgr.Create(new IdentityRole("test"));
            //userMgr.Create(new ApplicationUser() { UserName = "test" });

            // Then, you create the "canEdit" role if it doesn't already exist.
            //Replace "canEdit" with "AdminUsr"

            if (!roleMgr.RoleExists("AdminUsr"))
            {
                //IdRoleResult = roleMgr.Create(new IdentityRole { Name = "AdminUsr" });
                var roleresult = roleMgr.Create(new IdentityRole("AdminUsr"));
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.

            //--------------------------------------------------------------------------------------
            //var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var appUser = new ApplicationUser
            //{
            //    UserName = "admin@tropica.com",
            //    Email = "admin@tropica.com",
            //    FirstName = "Johnny",
            //    LastName = "Bravo"
            // };
            //IdUserResult = userMgr.Create(appUser, "Pa$$word1");
            //--------------------------------------------------------------------------------------

            ////--------------------------------------------------------------------------------------

            //var user = new ApplicationUser() { UserName = "admin@tropica.com", Email = "admin@tropica.com", FirstName = "Johnny", LastName = "Bravo" };

            ////--------------------------------------------------------------------------------------

            var user = new ApplicationUser();
            user.UserName = "admin@sanantonio.com";
            user.Email = "admin@sanantonio.com";
            user.FirstName = "Jhonny";
            user.LastName = "Bravo";
            user.BirthDate = new DateTime(1975, 5, 15);
            user.PhoneNumber = "0171209837";
            var adminresult = userMgr.Create(user, "SuperSecret@1");

            if (adminresult.Succeeded)
            {
                var result = userMgr.AddToRole(user.Id, "AdminUsr");
            }


            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            //------------------------------------------------------------------------------------------
            //if (!userMgr.IsInRole(userMgr.FindByEmail("admin@tropica.com").Id, "AdminUsr")) 
            //{
                                              
            //    IdentityResult result = userMgr.Create(user, "Pass$#@1");
            //    result = userMgr.AddToRole(userMgr.FindByEmail("admin@tropica.com").Id, "AdminUsr");
            //}
        }
    }
}