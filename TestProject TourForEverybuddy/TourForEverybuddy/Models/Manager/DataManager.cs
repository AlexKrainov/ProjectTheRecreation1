using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TourForEverybuddy.Models
{
    public partial class DataManager
    {
        private TourForEverybuddyDatabaseContext db;
        public DataManager()
        {
            db = new TourForEverybuddyDatabaseContext();
        }

        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        public IQueryable<Language> GetLanguages()
        {
            return db.Languages;
        }

        internal IQueryable<UserLanguage> GetUserLanguages(int userID)
        {
            return db.UserLanguages.Where(x => x.UserID == userID);
        }

      
    }
}