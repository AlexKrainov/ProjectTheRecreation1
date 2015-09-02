using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour_Duration
    {
        public Tour_Duration()
        {
            this.Tours = new List<Tour>();
        }

        public byte Id { get; set; }
        public string Time { get; set; }
        public string TimeRus { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
