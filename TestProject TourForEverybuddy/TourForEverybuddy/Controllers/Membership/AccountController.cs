using System;
using System.Collections.Generic;
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

#warning Нужно ли передовать id ? (Он засветичиватеся в URL  троке )
        [HttpGet]
        public ActionResult Edit(int id) 
        {            
            var user = Storage.currentUser;
            if (user == null || user.id != id)
                return RedirectToAction("Index", "Login", new { returnUrl = Request.UrlReferrer.OriginalString });

            FillDropDownList(user.id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user, string[] Language)
        {
            if(this.ModelState.IsValid)
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