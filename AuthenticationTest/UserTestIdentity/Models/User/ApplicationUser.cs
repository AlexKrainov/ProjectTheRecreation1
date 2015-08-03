using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace UserTestIdentity.Models.User
{
    public class ApplicationUser : IdentityUser
    {

        //public ApplicationUser(string name)
        //{
        //    Id = Guid.NewGuid().ToString();
        //    UserName = name;

        //}

        //public string Id { get; private set; }

        //public string UserName { get; set; }
    }
}