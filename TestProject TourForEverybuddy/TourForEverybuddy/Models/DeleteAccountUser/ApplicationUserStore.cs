using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourForEverybuddy.Models.AccountUser
{
    /// <summary>
    /// является хранилищем пользователей и включает базовые методы (Create, Update, Delete)
    /// для работы с ними. Здесь я использую для хранения статическое поле Users. 
    /// Здесь же можно прикрутить любое, подходящее для вас хранилище. 
    /// Также нельзя не обратить внимание на тип возвращаемого значения — Task и Task. Это означает, что методы будут выполняться асинхронно. 
    /// </summary>
    public class ApplicationUserStore : IUserStore<ApplicationUser>
    {
        public System.Threading.Tasks.Task CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}