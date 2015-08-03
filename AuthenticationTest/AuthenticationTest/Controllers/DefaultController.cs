using AuthenticationTest.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationTest.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        //[Authorize(Users = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        
        [MyAuthentication]
        [HttpPost]
        public ActionResult Index(string n)
        {
            return RedirectToAction("NewIndex");
        }

        [HttpGet]
        public ActionResult NewIndex()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Users = "admin")]
        public ActionResult NewIndex(string s )
        {
            AuthorizationContext c = new AuthorizationContext();
            var z = this;
            return RedirectToAction("NewIndex2");
        }

        public ActionResult NewIndex2(string s)
        {
            AuthorizationContext c = new AuthorizationContext();
            var z = this;
            return View();
        }


    }
}