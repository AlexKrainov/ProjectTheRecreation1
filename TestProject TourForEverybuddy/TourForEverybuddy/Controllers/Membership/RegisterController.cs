using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using TourForEverybuddy.Models;
using TourForEverybuddy.Models.ViewModels;
using Postal;

namespace TourForEverybuddy.Controllers
{
    public class RegisterController : Controller
    {
        private DataManager manager;
        public RegisterController()
        {
            manager = new DataManager();
        }

        public ActionResult User(LoginViewModel loginModel)
        {
            ViewBag.Countries =
                manager.GetCountries().Select(x => new SelectListItem { Text = x.country_name, Value = x.id.ToString() }).ToList();
            ViewBag.Languages =
                manager.GetLanguages().Select(x => new SelectListItem { Text = x.name, Value = x.id.ToString() }).ToList();

            ViewBag.Model = new { Name = loginModel.Name, Email = loginModel.Email };

            return View();
        }

        [HttpPost]
        public ActionResult User(User user)
        {
            if (this.ModelState.IsValid)
            {
                manager = new DataManager();
                bool isNew = manager.CheckUserIsNew(user);

                if (isNew)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("EmailIsHave", "This email is already registered");
            }
            else
            {
                ModelState.AddModelError("ValidIsFailed", "Validation Faild");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Agreement()
        {

            return View();
        }

        
    }
}