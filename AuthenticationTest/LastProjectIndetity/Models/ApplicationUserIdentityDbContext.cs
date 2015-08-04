using LastProjectIndetity.Models.WorkWithUsers;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastProjectIndetity.Models
{
    public class ApplicationUserIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserIdentityDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationUserIdentityDbContext Create()
        {
            return new ApplicationUserIdentityDbContext();
        }

    }
}