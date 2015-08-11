using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}