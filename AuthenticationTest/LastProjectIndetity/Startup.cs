using Microsoft.Owin;
using Owin;
using LastProjectIndetity.Models.WorkWithUsers;
using Microsoft.AspNet.Identity;

namespace LastProjectIndetity
{
    [assembly: OwinStartupAttribute(typeof(LastProjectIndetity.Startup))]
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}