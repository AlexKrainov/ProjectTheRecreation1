using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourForEverybuddy.Models;

namespace TourForEverybuddy.Controllers.BasicControllers
{
    public class BaseController : Controller
    {
       protected DataManager manager;
        public BaseController()
        {
            manager = new DataManager();
        }
    }
}