using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Models.AccountUser;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace TourForEverybuddy.Controllers
{
    public class AccountController : Controller
    {
        public async  Task<ActionResult> Register()
        {
            var user = new ApplicationUser { UserName = "alex", Password = "alexx" };
            var identity = await AppUserManager.CreateAsync(user);

            return View();
        }
    }
}