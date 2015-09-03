using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class UserLanguage
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public Nullable<short> LanguageID { get; set; }
        public virtual Language Language { get; set; }
        public virtual User User { get; set; }
    }
}
