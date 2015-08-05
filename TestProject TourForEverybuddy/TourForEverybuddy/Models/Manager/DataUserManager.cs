using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourForEverybuddy.Models
{
    public partial class DataManager
    {
        internal bool CheckUserIsNew(User user)
        {
            //ToDo: Дописать провеку ...
            var oldUser = db.Users.FirstOrDefault(x => x.Email == user.Email && x.Name == user.Name);

            if (oldUser != null)
                return false;
            else
            {
                user.DateRegister = DateTime.Now;
                SaveNewUser(user);
            }

            return true;
        }
        internal bool CheckUserLogin(string Name, string Password)
        {
            var oldUser = db.Users.FirstOrDefault(x => x.Name == Name && x.Password == Password);

            if (oldUser == null)
                return false;

            oldUser.LastAuthorization = DateTime.Now;
            db.SaveChanges();

            return true;
        }
        private void SaveNewUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }


    }
}