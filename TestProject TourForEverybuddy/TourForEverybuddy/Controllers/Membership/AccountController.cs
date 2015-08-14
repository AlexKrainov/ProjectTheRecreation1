using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models.Filters;

namespace TourForEverybuddy.Controllers.Membership
{
    public class AccountController : Controller
    {
        //[MyAuthorize(Users = "admin, Alex", Roles = "admin")]
        [MyAuthentication]
        public ActionResult Index()
        {
            var user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            //ViewBag.User = user
            return View(user);
        }
    }
}