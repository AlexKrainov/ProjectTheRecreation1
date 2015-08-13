using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Models.ViewModels;

namespace TourForEverybuddy.Controllers.Membership
{
    public class EmailsController : Controller
    {
        [HttpGet]
        public ActionResult ForgotThePassword(LoginViewModel loginModel)
        {
            dynamic email = new Email("ForgotThePassword");
            email.To = "ialexkrainov2@gmail.com";
            email.FunnyLink = "Hello Alex :)";
            email.Send();

            return View();
        }
    }
}