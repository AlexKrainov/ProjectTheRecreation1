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
            db.Tours.Add(tour);

            db.SaveChanges();

            return true;
        }
    }
}