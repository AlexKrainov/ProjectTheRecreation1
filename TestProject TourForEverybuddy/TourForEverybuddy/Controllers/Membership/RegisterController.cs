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
            FillDropDownList();
            ViewBag.Model = new { Name = loginModel.Name, Email = loginModel.Email };

            return View();
        }

        [HttpPost]
        public ActionResult User(User user, string[] Language)
        {
            if (this.ModelState.IsValid)
            {
                manager = new DataManager();
                bool isNew = manager.CheckUserIsNew(user);

                if (isNew)
                {
                    manager.SaveNewUser(user);
                    manager.SaveUserLanguages(user.id, Language);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    FillDropDownList();
                    ModelState.AddModelError("EmailIsHave", "This user is already registered.");
                }
            }
            else
                ModelState.AddModelError("ValidIsFailed", "Fail.");

            return View();
        }

        /// <summary>
        /// Заполняет DropDownList's для Countries and Languages
        /// </summary>
        private void FillDropDownList()
        {
            ViewBag.Countries =
                manager.GetCountries().Select(x => new SelectListItem { Text = x.country_name, Value = x.id.ToString() }).ToList();

            ViewBag.Languages =
                manager.GetLanguages().Select(x => new SelectListItem { Text = x.name, Value = x.id.ToString() });
        }

    }
}