using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastProjectIndetity.Models.WorkWithUsers
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public string Password { get; set; }
    }
}