using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourForEverybuddy.Models.ViewModels;

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
        internal bool CheckUserLogin(LoginViewModel loginModel,ref string name )
        {
            User user = null;

            if (!string.IsNullOrEmpty(loginModel.Name))
                user = db.Users.FirstOrDefault(x => x.Name == loginModel.Name && x.Password == loginModel.Password);
            else if (!string.IsNullOrEmpty(loginModel.Email))
                user = db.Users.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

            name = user.Name;

            if (user == null)
                return false;

            user.LastAuthorization = DateTime.Now;
           
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