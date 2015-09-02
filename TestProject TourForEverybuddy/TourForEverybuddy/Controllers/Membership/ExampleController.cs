using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Membership
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Index()
        {
            DataManager manager = new DataManager();
            //var user = Storage.currentUser;
           var  user = manager.GetUser(3);

           var list = manager.GetUserLanguages(user.id).Select(x => x.Language.name).ToList();
           ViewBag.UserLanguage = list;
            return View(user);
        }
    }
}