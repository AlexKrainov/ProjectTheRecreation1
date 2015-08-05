using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCoockie.Models;

namespace TestCoockie.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TourForEverybuddyDatabaseContext db = new TourForEverybuddyDatabaseContext();

            return View(db.Users);
        }
    }
}