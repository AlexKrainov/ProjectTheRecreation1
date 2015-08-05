using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TourForEverybuddy.Models.AccountUser
{
    class ApplicationUserIdentityDbContext : IdentityDbContext
    {
        public ApplicationUserIdentityDbContext()
            : base("DefaultConnection")
        {
            var z = this.Users;
        }

        public static ApplicationUserIdentityDbContext Create()
        {
            return new ApplicationUserIdentityDbContext();
        }

    }
}
