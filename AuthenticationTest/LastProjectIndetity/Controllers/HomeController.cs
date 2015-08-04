using LastProjectIndetity.Models.WorkWithUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Security;

namespace LastProjectIndetity.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager appUserManager;

        public ApplicationUserManager AppUserManager
        {
            get { return appUserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { appUserManager = value; }
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(ApplicationUser user, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                var identity = await AppUserManager.CreateAsync(user);

                if (identity.Succeeded)
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
            }


            return RedirectToAction("Main", "Default");
        }
    }
}