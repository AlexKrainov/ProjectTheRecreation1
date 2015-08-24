using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourForEverybuddy.Models
{
    public partial class DataManager
    {
        internal bool CreateTour(Tour tour)
        {
            //ToDo: Проверка
            if (db.Tours.FirstOrDefault(x => x.title == tour.title) != null)
                return false;

            db.Tours.Add(tour);
            db.SaveChanges();

            return true;
        }
    }
}