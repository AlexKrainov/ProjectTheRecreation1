using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour
    {
        public Tour()
        {
            this.Tour_CommentOfTour = new List<Tour_CommentOfTour>();
            this.Tour_PictureOfTour = new List<Tour_PictureOfTour>();
            this.Tour_DaysOfTheWeek = new List<Tour_DaysOfTheWeek>();
        }

        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int userID { get; set; }
        public Nullable<bool> disable { get; set; }
        public int cityID { get; set; }
        public string fullDescription { get; set; }
        public Nullable<byte> MaximumTravelers { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<byte> durationID { get; set; }
        public string startsAt { get; set; }
        public virtual ICollection<Tour_CommentOfTour> Tour_CommentOfTour { get; set; }
        public virtual ICollection<Tour_PictureOfTour> Tour_PictureOfTour { get; set; }
        public virtual ICollection<Tour_DaysOfTheWeek> Tour_DaysOfTheWeek { get; set; }
        public virtual Tour_Cities Tour_Cities { get; set; }
        public virtual Tour_Duration Tour_Duration { get; set; }
        public virtual User User { get; set; }
    }
}
