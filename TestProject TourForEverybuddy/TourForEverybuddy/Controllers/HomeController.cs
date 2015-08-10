using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            loginModel.Name = "admin"; loginModel.Password = "admin"; loginModel.Email = "admin";
            if (IsRegister)
                return RedirectToAction("Register", "Account", new { Name = loginModel.Name, Email = loginModel.Email });
            else
                return RedirectToAction("Index", "Login", new
                {
                    Name = loginModel.Name,
                    Email = loginModel.Email,
                    Password = loginModel.Password,
                    returnUrl = Request.Url.OriginalString,
                });
        }

    }

}