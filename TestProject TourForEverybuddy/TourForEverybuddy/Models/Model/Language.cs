using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Language
    {
        public Language()
        {
            this.UserLanguages = new List<UserLanguage>();
        }

        public short id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
    }
}
