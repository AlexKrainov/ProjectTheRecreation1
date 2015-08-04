using LastProjectIndetity.Models.WorkWithUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace LastProjectIndetity.Controllers
{

    public class DefaultController : Controller
    {
        private ApplicationUserManager appUserManager;

        public ApplicationUserManager AppUserManager
        {
            get { return appUserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { appUserManager = value; }
        }
        public ActionResult Main()
        {

            var keys = Response.Cookies.AllKeys;
            var users = AppUserManager.Users;

            var user = User.Identity.IsAuthenticated;

            return View();
        }
    }
}