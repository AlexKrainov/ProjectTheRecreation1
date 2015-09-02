using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Tour_PictureOfTour
    {
        public int Id { get; set; }
        public int TourID { get; set; }
        public byte[] Picture { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
