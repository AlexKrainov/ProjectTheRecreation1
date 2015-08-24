using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Controllers.Static;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.Elements
{
    public class PictureController : Controller
    {
        // GET: Picture
        public ActionResult Show(int id)
        {
            var tour = Storage.currentUser.Tours.FirstOrDefault(x => x.Id == id);

            if (tour.Tour_PictureOfTour.Count >= 0)
                return File(tour.Tour_PictureOfTour.ElementAt(0).Picture, tour.Tour_PictureOfTour.ElementAt(0).ContentType);

            return File("pic01.jpg", "image/jpeg");
        }
    }
}