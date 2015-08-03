using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserTestIdentity.Models.User;

namespace UserTestIdentity.Controllers
{
    public class DefaultController : Controller
    {
        private static CustomUserManager _customUserManager;
        public CustomUserManager UserManager
        {
            get
            {
                return _customUserManager;//??
                     //  (_customUserManager = new Microsoft.Owin.Host.SystemWeb HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>());
            }
        }

        public async Task<bool> Authenticate(string name, string password)
        {
            if (await UserManager.FindAsync(name, password) != null)
            {
                return true;
            }

            return false;
        }

        public ActionResult Index()
        {
            var t = HttpContext.User;

            FormsAuthentication.SetAuthCookie("alex", false);

            var z = HttpContext.User;


            List<ApplicationUser> users = new List<ApplicationUser>();
            using(ApplicationContext db = new ApplicationContext())
            {
                users = db.Users.ToList();
            }

            Authenticate("alex", "alex");

            return View();
        }
    }
}