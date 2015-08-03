using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestIdentity.Models.UserFolder
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
            : base ("")
        {
            
        }



    }
}