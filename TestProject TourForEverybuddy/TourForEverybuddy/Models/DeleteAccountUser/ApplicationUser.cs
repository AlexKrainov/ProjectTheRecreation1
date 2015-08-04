using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourForEverybuddy.Models.AccountUser
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public bool Guide { get; set; }
    }
}