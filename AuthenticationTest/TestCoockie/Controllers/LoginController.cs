using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestCoockie.Models;

namespace TestCoockie.Controllers
{
    public class LoginController : Controller
    {
        public TourForEverybuddyDatabaseContext db;
        public LoginController()
        {
            db = new TourForEverybuddyDatabaseContext();
        }

        public ActionResult Index()
        {
            FormsAuthentication.SignOut();

            return View();
        }

        [HttpPost]
        public ActionResult Index(string Name, string Email, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(x => x.Name == Name && x.Email == Email);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(Name, false);
                }else
                {
                    this.ModelState.AddModelError("Login", " Неверная пара Имя-Емейл");
                    return View();
                }
            }


            return RedirectToAction("Index","Home");
        }

    }
}