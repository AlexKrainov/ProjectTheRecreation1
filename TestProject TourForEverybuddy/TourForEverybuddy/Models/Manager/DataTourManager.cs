using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourForEverybuddy.Controllers.Static;

namespace TourForEverybuddy.Models
{
    public partial class DataManager
    {
        internal bool CreateTour(Tour tour)
        {
            //ToDo: Проверка
            if (db.Tours.FirstOrDefault(x => x.title == tour.title) != null)
                return false;

            try
            {
                db.Tours.Add(tour);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool UpdateTour(Tour tour)
        {
            try
            {
                var oldTour = db.Tours.FirstOrDefault(x => x.Id == tour.Id);

                oldTour.title = tour.title;
                oldTour.description = tour.description;

                for (int i = 0; i < tour.Tour_PictureOfTour.Count; i++)
                    oldTour.Tour_PictureOfTour.Add(tour.Tour_PictureOfTour.ElementAt(i));

                db.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        internal bool DeletePictures(int tourID, string[] arrayPicture)
        {
            try
            {
                var tour = db.Tours.FirstOrDefault(x => x.Id == tourID);
                if (tour == null)
                    return false;

                for (int i = 0; i < arrayPicture.Length; i++)
                {
                    //   tour.Tour_PictureOfTour.Remove(tour.Tour_PictureOfTour.FirstOrDefault(x => x.Id.ToString() == arrayPicture[i]));
                    string id = arrayPicture[i];
                    if (!string.IsNullOrEmpty(id))
                        db.Tour_PictureOfTour.Remove(db.Tour_PictureOfTour.FirstOrDefault(x => x.Id.ToString() == id));
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        //Удалять ли или помечать как удаленный тур
        internal bool DeleteTour(int tourID)
        {
            try
            {
                //DeletePictures(tourID, db.Tour_PictureOfTour.Where(x => x.TourID == tourID).Select(x => x.Id.ToString()).ToArray());
                //db.Tours.Remove(db.Tours.FirstOrDefault(x => x.Id == tourID));
                var oldTour = db.Tours.FirstOrDefault(x => x.Id == tourID);
                oldTour.disable =  true;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        internal Tour GetTour(int tourID)
        {
            return db.Tours.FirstOrDefault(x => x.Id == tourID);
        }
    }
}