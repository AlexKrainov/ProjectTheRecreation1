using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Membership
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Name , string Password, string returnUrl)
        {
            DataManager manager = new DataManager();
            bool have = manager.CheckUserLogin(Name, Password);
            
            if(have)
            {
                FormsAuthentication.SetAuthCookie(Name, true);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }else
            {
                ModelState.AddModelError("LoginAndPassword_DoesNotMatch", "Name and password does not match");
                return View();
            }
        }

    }
}