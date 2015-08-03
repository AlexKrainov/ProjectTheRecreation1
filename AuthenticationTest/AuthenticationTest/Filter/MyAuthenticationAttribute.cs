using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace AuthenticationTest.Filter
{
    public class MyAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;

            if (!ident.IsAuthenticated || !(ident.Name == "admin" || ident.Name == "alex"))
                filterContext.Result = new HttpUnauthorizedResult(); //доступ к данному ресурсу для пользовател запрещен
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary{
                    {"controller", "Home"},
                    {"action", "Login"},
                    {"returnUrl", filterContext.HttpContext.Request.Url }
                });
            }
            
        }
    }
}