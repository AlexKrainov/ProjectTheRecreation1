using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour_CommentOfTour
    {
        public int Id { get; set; }
        public int TourID { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual User User { get; set; }
    }
}
