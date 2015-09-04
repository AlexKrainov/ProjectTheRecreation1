using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourForEverybuddy.Controllers.Static;

namespace TourForEverybuddy.Models
{
    public partial class DataManager
    {
        internal bool CreateTour(Tour tour, string[] arrayDaysOfTheWeek)
        {
            //ToDo: Проверка
            if (db.Tours.FirstOrDefault(x => x.title == tour.title) != null)
                return false;

            try
            {
                db.Tours.Add(tour);
                db.SaveChanges();

                for (int i = 0; i < arrayDaysOfTheWeek.Length; i++)
                    if (!string.IsNullOrEmpty(arrayDaysOfTheWeek[i]))
                        db.Tour_DaysOfTheWeek.Add(
                            new Tour_DaysOfTheWeek { DaysOfTheWeekID = Convert.ToByte(arrayDaysOfTheWeek[i]), TourID = tour.Id });

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        internal bool UpdateTour(Tour tour, string[] arrayDaysOfTheWeek)
        {
            try
            {
                var oldTour = db.Tours.FirstOrDefault(x => x.Id == tour.Id);

                oldTour.title = tour.title;
                oldTour.description = tour.description;
                oldTour.cityID = tour.cityID;
                oldTour.durationID = tour.durationID;
                oldTour.fullDescription = tour.fullDescription;
                oldTour.MaximumTravelers = tour.MaximumTravelers;
                oldTour.price = tour.price;
                oldTour.startsAt = tour.startsAt;

                for (int i = 0; i < tour.Tour_PictureOfTour.Count; i++)
                    oldTour.Tour_PictureOfTour.Add(tour.Tour_PictureOfTour.ElementAt(i));

                db.SaveChanges();

                #region Update days of the week

                db.Tour_DaysOfTheWeek.RemoveRange(db.Tour_DaysOfTheWeek.Where(x => x.TourID == oldTour.Id));

                db.SaveChanges();

                for (int i = 0; i < arrayDaysOfTheWeek.Length; i++)
                    if (!string.IsNullOrEmpty(arrayDaysOfTheWeek[i]))
                        db.Tour_DaysOfTheWeek.Add(
                            new Tour_DaysOfTheWeek { DaysOfTheWeekID = Convert.ToByte(arrayDaysOfTheWeek[i]), TourID = tour.Id });

                db.SaveChanges();
                #endregion
            }
            catch (Exception ex)
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
                oldTour.disable = true;

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

        internal IQueryable<Tour_Cities> GetCities()
        {
            return db.Tour_Cities;
        }
        internal IQueryable<Tour_Duration> GetDuration()
        {
            return db.Tour_Duration;
        }

        internal IQueryable<DaysOfTheWeek> GetDayOfTheWeek()
        {
            return db.DaysOfTheWeeks;
        }

        internal IQueryable<Tour_DaysOfTheWeek> GetTour_DaysOfTheWeek(int tourID)
        {
            return db.Tour_DaysOfTheWeek.Where(x => x.TourID == tourID);
        }


    }
}