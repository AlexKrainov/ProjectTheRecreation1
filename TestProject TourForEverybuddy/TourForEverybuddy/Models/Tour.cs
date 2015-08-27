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
        }

        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<bool> disable { get; set; }
        public virtual ICollection<Tour_CommentOfTour> Tour_CommentOfTour { get; set; }
        public virtual ICollection<Tour_PictureOfTour> Tour_PictureOfTour { get; set; }
        public virtual User User { get; set; }
    }
}
