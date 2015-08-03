using AuthenticationTest.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationTest.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string pwd, string returnUrl)
        {
            if (login == "admin" && pwd == "admin")
            {
                var keys = Response.Cookies.AllKeys;
                FormsAuthentication.SetAuthCookie(login, false); // устанавливаем куки 

               var cookie = new HttpCookie("text_cookie");
//                cookie.Name = "test_cookie";
                cookie.Value = DateTime.Now.Year.ToString();
                cookie.Expires = DateTime.Now.AddMinutes(5);
                Response.SetCookie(cookie);

                var user = User.Identity.IsAuthenticated;

                return Redirect(returnUrl ?? Url.Action("Index", "Default"));
            }
            else
            {
                ModelState.AddModelError("", "Некорректное имя пользователя или пароль");
                return View();
            }
        }

    }
}