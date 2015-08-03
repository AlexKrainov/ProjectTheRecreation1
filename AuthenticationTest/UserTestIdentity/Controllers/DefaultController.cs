using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserTestIdentity.Models.User;

namespace UserTestIdentity.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            using(ApplicationContext db = new ApplicationContext())
            {
                users = db.Users.ToList();
            }


            return View();
        }
    }
}