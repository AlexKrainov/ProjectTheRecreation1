using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.BasicControllers;

namespace TourForEverybuddy.Controllers.View
{
    public class TourController : BaseController
    {
        public ActionResult TourView(int? tourID)
        {
            var tour = manager.GetTour(tourID ?? 0);

            if (tour != null)
            {
                ViewBag.DaysOfTheWeek = manager.GetTour_DaysOfTheWeek(tour.Id).ToList();
                return View(tour);
            }
            else
                return View();// ToDo: redirect to empty tour

        }
    }
}