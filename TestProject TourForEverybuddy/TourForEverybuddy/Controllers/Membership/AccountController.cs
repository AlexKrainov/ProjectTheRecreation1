using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models;
using TourForEverybuddy.Models.Filters;

namespace TourForEverybuddy.Controllers.Membership
{
    [MyAuthentication]
    public class AccountController : Controller
    {
        //[MyAuthorize(Users = "admin, Alex", Roles = "admin")]

        public ActionResult Index()
        {
            DataManager manager = new DataManager();

            ViewBag.Countries =
               manager.GetCountries().Select(x => new SelectListItem { Text = x.country_name, Value = x.id.ToString() }).ToList();

            ViewBag.Languages =
                manager.GetLanguages().Select(x => new SelectListItem { Text = x.name, Value = x.id.ToString() });

            var user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            //ViewBag.User = user
            return View(user);
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            //ViewBag.User = user
            return View(user);
        }

        [HttpPost]
        public ActionResult EditName(User user)
        {
            user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            //ViewBag.User = user
            return View(user);
        }
    }
}