using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourForEverybuddy.Models;
using TourForEverybuddy.Models.ViewModels;

namespace TourForEverybuddy.Controllers.Membership
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Index(LoginViewModel loginModel, string returnUrl, bool? a = null)
        {
            if (String.IsNullOrEmpty(loginModel.Name) && String.IsNullOrEmpty(loginModel.Email) && String.IsNullOrEmpty(loginModel.Password))
                return View();
            
              var ab = Index(loginModel, returnUrl);

              return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel loginModel, string returnUrl)
        {
            DataManager manager = new DataManager();
            string name = "";
            bool have = manager.CheckUserLogin(loginModel, ref name);

            
            if (have)
            {
                FormsAuthentication.SetAuthCookie(name, true);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            else
            {
                ModelState.AddModelError("LoginAndPassword_DoesNotMatch", "Name and password does not match");
                return View();
            }
        }

    }
}