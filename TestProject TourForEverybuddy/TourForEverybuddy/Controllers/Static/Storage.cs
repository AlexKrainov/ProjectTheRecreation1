using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TourForEverybuddy.Controllers.Static
{
    public static class Storage
    {
        public static int GetUserID()
        {
           var user = FormsAuthentication.GetAuthCookie("", true);
           HttpCookie cookie = new HttpCookie("buddy");
            var usrOld = HttpContext.Current.User.Identity;
            return 0;
        }
    }
}