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
        private string ReturnUrl;
        public ActionResult Index(LoginViewModel loginModel, string returnUrl)
        {
            if (String.IsNullOrEmpty(loginModel.NameOrEmail) && String.IsNullOrEmpty(loginModel.Password))
                return View();

            ReturnUrl = returnUrl;
            Index(loginModel, returnUrl, true);

            if (string.IsNullOrEmpty(ReturnUrl))
                return View();
            else
                return Redirect(ReturnUrl);// ?? Url.Action("Index", "Home"));
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel loginModel, string returnUrl, bool? a = null)
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
                loginModel.Password = null;
                ReturnUrl = "";
                //returnUrl = Url.Action("Index", "Login", new { NameOrEmail = loginModel.NameOrEmail });
                ModelState.AddModelError("LoginAndPassword_DoesNotMatch", "Name and password does not match");
                return View();
            }
        }

    }
}