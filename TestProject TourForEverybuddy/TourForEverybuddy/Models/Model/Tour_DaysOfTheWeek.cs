using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour_DaysOfTheWeek
    {
        public byte Id { get; set; }
        public byte DaysOfTheWeekID { get; set; }
        public int TourID { get; set; }
        public virtual DaysOfTheWeek DaysOfTheWeek { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
