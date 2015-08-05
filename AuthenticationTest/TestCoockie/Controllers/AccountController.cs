using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCoockie.Models;

namespace TestCoockie.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            //Request - извлекать cookie-наборы
            //Response - устанавливать cookie-наборы
            HttpCookie cookie = new HttpCookie("MyCookie", "I will save the world !!!");
            cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Add(cookie);


            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;

           // bool IsAdmin = HttpContext.User.IsInRole("admin"); // определяем, принадлежит ли пользователь к администраторам
            bool IsAuth = HttpContext.User.Identity.IsAuthenticated; // аутентифицирован ли пользователь
            string login = HttpContext.User.Identity.Name; // логин авторизованного пользователя

            

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            HttpCookie cookieRequest = Request.Cookies["MyCookie"];

            //Удаление cookie-набора
            cookieRequest.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookieRequest);

            if (this.ModelState.IsValid)
            {
                TourForEverybuddyDatabaseContext db = new TourForEverybuddyDatabaseContext();
                db.Users.Add(user);
                db.SaveChanges();
            }


            return RedirectToAction("Index", "Home");
        }

    }
}