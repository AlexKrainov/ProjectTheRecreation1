using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Elements
{
    public class ElementController : Controller
    {
        private DataManager manager;
        public ElementController()
        {
            manager = new DataManager();
        }

        /// <summary>
        /// Control a tour
        /// </summary>
        /// <param name="tourID"></param>
        /// <param name="edit"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Tour(int tourID, bool edit = false)
        {
            ViewBag.Edit = edit;
            //manager.GetTour(tourID);
            return PartialView(manager.GetTour(tourID));
        }
    }
}