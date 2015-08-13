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
        [MyAuthentication]
        public ActionResult Index(int? id)
        {
            var userID = Storage.GetUserID();
            var userAuth = FormsAuthentication.GetAuthCookie("admin", true).Value;
            return View();
        }
    }
}