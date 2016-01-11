using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.BasicControllers;

namespace TourForEverybuddy.Controllers.ProfilePage
{
    public class ProfilePageController : BaseController
    {
        [HttpGet]
        public ActionResult UserProfile(int? userID)
        {
            var user = manager.GetUser(userID ?? 0);

            if (user != null)
                return View(user);
            else
                return View();// ToDo: redirect to empty user
        }
    }
}