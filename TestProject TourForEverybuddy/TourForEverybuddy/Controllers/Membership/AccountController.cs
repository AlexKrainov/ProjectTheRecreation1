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
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (this.ModelState.IsValid)
            {
                DataManager manager = new DataManager();
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