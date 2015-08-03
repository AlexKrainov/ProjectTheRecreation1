using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserTestIdentity.Models.User;

namespace UserTestIdentity
{
    [assembly: OwinStartupAttribute(typeof(UserTestIdentity.Startup))]
    public class Startup
    {
    
        public void Cofiguration(IAppBuilder app)
        {
           // app.CreatePerOwinContext()
        }
    }
}