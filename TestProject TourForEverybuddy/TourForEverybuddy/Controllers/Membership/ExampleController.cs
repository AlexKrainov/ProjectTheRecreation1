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
            
            ViewBag.UserLanguage = manager.GetUserLanguages(user.id).Select(x => x.Language.name).ToList();
            return View(user);
        }
    }
}