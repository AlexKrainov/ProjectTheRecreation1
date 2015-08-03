using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserTestIdentity.Models.User
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {

        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

    }
}