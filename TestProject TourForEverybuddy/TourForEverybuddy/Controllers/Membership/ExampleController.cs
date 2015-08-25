using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.Static;

namespace TourForEverybuddy.Controllers.Membership
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Index()
        {
            var tour = Storage.currentUser.Tours.FirstOrDefault(x => x.Id == 2);
            return View(tour);
        }
    }
}