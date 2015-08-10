using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            if (IsRegister)
                return RedirectToAction("Register", "Account", new { Name = loginModel.Name, Email = loginModel.Email });
            else
                return RedirectToAction("Index", "Login", new
                {
                    Name = loginModel.Name,
                    Email = loginModel.Email,
                    Password = loginModel.Password,
                    returnUrl = Request.UrlReferrer.OriginalString,
                });
        }

        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();

            return Redirect(Request.UrlReferrer.OriginalString);
        }

    }

}