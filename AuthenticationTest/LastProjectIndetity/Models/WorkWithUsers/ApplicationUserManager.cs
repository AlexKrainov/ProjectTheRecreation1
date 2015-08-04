using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LastProjectIndetity.Models.WorkWithUsers
{
    /// <summary>
    /// главный класс, методы которого мы будем вызывать для манипулирования пользовательскими данными.
    /// Он должен являться наследником Microsoft.AspNet.Identity.UserManager, который содержит множество виртуальных методов. 
    /// В данном случае мы переопределили метод FindAsync(), в котором для примера сначала проверяется пароль, и в случае успеха возвращается юзер.
    /// Как вы видите, в конструкторе UserManeger мы определили собственный PasswordHasher — класс, предназначенный для управления паролями. 
    /// Тело метода VerifyHashedPassword имеет демонстрационный вид. Вы же можете там написать свою логику проверки пароля.
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(UserStore<ApplicationUser> store)
            : base(store)
        {
            this.PasswordHasher = new ApplicationPasswordHasher();
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            ApplicationUserIdentityDbContext db = context.Get<ApplicationUserIdentityDbContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            return manager;
        }

        public override async System.Threading.Tasks.Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            var identity = await base.CreateAsync(user);
            
            return identity;
        }


    }

    public class ApplicationPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return base.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return base.VerifyHashedPassword(hashedPassword, providedPassword);
        }
    }

}