﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourForEverybuddy.Controllers
{
    public class GenericController : Controller
    {
        // GET: Generic
        public ActionResult Index()
        {
            return View();
        }
    }
}