using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TourForEverybuddy.Models.ViewModels;

namespace TourForEverybuddy.Models
{
    public partial class DataManager
    {
        internal bool CheckUserIsNew(User user)
        {
            var oldUser = db.Users.FirstOrDefault(x => (x.Email == user.Email && x.Name == user.Name)
                || (x.Name == user.Name && x.Password == user.Password)
                || (x.Email == user.Email && x.Password == user.Password));

            if (oldUser != null)
                return false;

            return true;
        }
        internal bool CheckUserLogin(LoginViewModel loginModel, ref string name, ref int id)
        {
            User user = null;

            if (string.IsNullOrEmpty(loginModel.NameOrEmail))
                return false;

            user = db.Users.FirstOrDefault(x => x.Name == loginModel.NameOrEmail && x.Password == loginModel.Password);

            if (user == null)
                user = db.Users.FirstOrDefault(x => x.Email == loginModel.NameOrEmail && x.Password == loginModel.Password);

            if (user == null)
                return false;

            name = user.Name;
            id = user.id;
            user.LastAuthorization = DateTime.Now;

            db.SaveChanges();

            return true;
        }
        internal void CreateUser(User user)
        {
            user.DateRegister = DateTime.Now;

            db.Users.Add(user);
            db.SaveChanges();
        }

        internal bool SaveUserLanguages(int userID, string[] Languages)
        {
            Languages = Languages.AsEnumerable().Where(x => x != "").ToArray();
            if (Languages.Count() == 0)
                return false;

            var oldUserLanguages = db.UserLanguages.Where(x => x.UserID == userID);
            db.UserLanguages.RemoveRange(oldUserLanguages);

            for (int i = 0; i < Languages.Length; i++)
                db.UserLanguages.Add(new UserLanguage { UserID = userID, LanguageID = Convert.ToInt16(Languages[i]) });

            db.SaveChanges();

            return true;
        }

        internal User GetUser(string userID, string userName)
        {
            int id = Convert.ToInt32(userID);
            return db.Users.FirstOrDefault(x => x.id == id && x.Name == userName);
        }

        internal IQueryable<UserType> GetRoles()
        {
            return db.UserTypes;
        }

        internal bool UpdateUser(User user, string[] Language)
        {
            var checkUser = db.Users.Where(x => x.Name == user.Name && x.Password == user.Password);
            if (checkUser.Count() > 1)
                return false;
            checkUser = db.Users.Where(x => x.Email == user.Email && x.Password == user.Password);
            if (checkUser.Count() > 1)
                return false;

            var oldUser = db.Users.FirstOrDefault(x => x.id == user.id);
            oldUser.Age = user.Age;
            oldUser.CountryId = user.CountryId;
            oldUser.Email = user.Email;
            oldUser.LastName = user.LastName;
            oldUser.Name = user.Name;
            oldUser.Password = user.Password;
            oldUser.Phone = user.Phone;

            db.SaveChanges();

            SaveUserLanguages(user.id, Language);

            return true;
        }
    }
}