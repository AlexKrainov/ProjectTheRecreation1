using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace TourForEverybuddy.Models.AccountUser
{
    public class Class1
    {
        private ApplicationUserManager appUserManager;
        public ApplicationUserManager AppUserManager
        {
           //get { return appUserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            get { return null; }
            set { appUserManager = value; }
        }
        public async Task<ActionResult> Register()
        {
            var user = new ApplicationUser { UserName = "alex", Password = "alexx" };
            var identity = await AppUserManager.CreateAsync(user);

            return null;// View();
        }
    }
}