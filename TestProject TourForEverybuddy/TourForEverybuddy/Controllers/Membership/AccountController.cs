using System;
using System.Collections.Generic;
using System.IO;
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
        private DataManager manager;
        //[MyAuthorize(Users = "admin, Alex", Roles = "admin")]
        public AccountController()
        {
            manager = new DataManager();
        }
        public ActionResult Index()
        {
            var user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer != null ? Request.UrlReferrer.OriginalString : "" });

            //ToDo: add Langues
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            FillDropDownList(user.id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user, string[] Language)
        {
            if (this.ModelState.IsValid)
            {
                var updated = manager.UpdateUser(user, Language);

                if (updated)
                {
                    Storage.currentUser = null;
                    return RedirectToAction("Index");
                }
                else
                {
                    FillDropDownList(user.id);
                    ModelState.AddModelError("EmailIsHave", "This user is already registered.");
                }
            }
            else
                ModelState.AddModelError("ValidIsFailed", "Fail.");

            return View();

        }

        [HttpGet]
        public ActionResult AddTour()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTour(Tour tour, HttpPostedFileBase[] Pictures)
        {
            //Перенести Storage.currentUser (добычу) currentUser  в MyAuthentication
            var user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            tour.userID = user.id;

            #region Get pictures
            if (Pictures.Count() > 0)
            {
                for (int i = 0; i < Pictures.Count(); i++)
                {
                    var picture = new Tour_PictureOfTour();
                    picture.FileName = Pictures[i].FileName;
                    picture.ContentType = Pictures[i].ContentType;

                    using (var reader = new BinaryReader(Pictures[i].InputStream))
                    {
                        picture.Picture = reader.ReadBytes(Pictures[i].ContentLength);
                    }

                    tour.Tour_PictureOfTour.Add(picture);
                }
            }
            #endregion

            if (!manager.CreateTour(tour))
            {
                ModelState.AddModelError("ValidIsFailed", "I can't save the tour");
                return View();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditTour()
        {
            var user = Storage.currentUser;
            if (user == null)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            //manager.GetUserTour(user.id);

            return View();
        }

        private void FillDropDownList(int userID)
        {
            ViewBag.Countries =
              manager.GetCountries().Select(x => new SelectListItem { Text = x.country_name, Value = x.id.ToString() }).ToList();

            ViewBag.Languages = manager.GetLanguages();

            var list = manager.GetUserLanguages(userID);
            ViewBag.ArrayLanguages = list;
        }
    }
}