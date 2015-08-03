using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UserTestIdentity.Models.User
{
    public class CustomUserManager :   UserManager<ApplicationUser>
    {

        public CustomUserManager(IUserStore<ApplicationUser> store)
            : base (store)
        {
           // this.PasswordHasher = new CustomPasswordHasher();
        }

        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options,
                IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            CustomUserManager manager = new CustomUserManager( new UserStore<ApplicationUser>(db));
            return manager;
        }

        public override System.Threading.Tasks.Task<ApplicationUser> FindAsync(string userName, string password)
        {
            Task<ApplicationUser> taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(userName, password);

                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                    return Store.FindByNameAsync(userName).Result;

                return null;
            });
            return taskInvoke;
        }
        

    }
    public class CustomPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return base.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            //свою логику проверки пароля.
            if (true)
                return PasswordVerificationResult.SuccessRehashNeeded;
            else
                return PasswordVerificationResult.Failed;
        }

    }
}