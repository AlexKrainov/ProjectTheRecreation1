using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourForEverybuddy.Controllers.Membership;
using TourForEverybuddy.Models.ViewModels;

namespace TourForEverybuddy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginModel, bool IsRegister)
        {
           // IsRegister = IsRegister ?? false;

            if (IsRegister)
            {
                if (!string.IsNullOrEmpty(loginModel.NameOrEmail))
                    ParsingLoginNameOrEmail(loginModel);
                return RedirectToAction("Register", "Account", new { Name = loginModel.Name, Email = loginModel.Email });
            }
            else
            {
                return RedirectToAction("Index", "Login", new
                {
                    NameOrEmail = loginModel.NameOrEmail,
                    Password = loginModel.Password,
                    RememberMe = loginModel.RememberMe,
                    returnUrl = Request.UrlReferrer.OriginalString,
                });
            }
        }

        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();

            return Redirect(Request.UrlReferrer.OriginalString);
        }


        private void ParsingLoginNameOrEmail(LoginViewModel loginModel)
        {
            var z = loginModel.NameOrEmail.IndexOf('@'); ;

            if (loginModel.NameOrEmail.IndexOf('@') == -1)
                loginModel.Name = loginModel.NameOrEmail;
            else
                loginModel.Email = loginModel.NameOrEmail;
        }
    }

}