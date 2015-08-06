using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers
{
    public class AccountController : Controller
    {
        private DataManager manager;
        public AccountController()
        {
            manager = new DataManager();
        }
        public ActionResult Register()
        {
            ViewBag.Countries =
                manager.GetCountries().Select(x => new SelectListItem { Text = x.country_name, Value = x.id.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
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

    }
}