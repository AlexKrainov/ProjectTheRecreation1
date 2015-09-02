using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour_StartsAt
    {
        public Tour_StartsAt()
        {
            this.Tours = new List<Tour>();
        }

        public int Id { get; set; }
        public string Time { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
