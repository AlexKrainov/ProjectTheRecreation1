using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour_Cities
    {
        public Tour_Cities()
        {
            this.Tours = new List<Tour>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string NameRus { get; set; }
        public string FederalSubject { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
