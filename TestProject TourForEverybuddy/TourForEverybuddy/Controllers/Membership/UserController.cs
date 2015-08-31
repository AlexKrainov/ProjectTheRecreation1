using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Membership
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Profile(int id)
        {
            DataManager manager = new DataManager();
            var currentUser = manager.GetUser(id);
            ViewBag.UserLanguage = manager.GetUserLanguages(currentUser.id).Select(x => x.Language.name).ToList();
            return View(currentUser);

            return View();
        }
    }
}