using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class DaysOfTheWeek
    {
        public DaysOfTheWeek()
        {
            this.Tour_DaysOfTheWeek = new List<Tour_DaysOfTheWeek>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string NameRus { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public virtual ICollection<Tour_DaysOfTheWeek> Tour_DaysOfTheWeek { get; set; }
    }
}
