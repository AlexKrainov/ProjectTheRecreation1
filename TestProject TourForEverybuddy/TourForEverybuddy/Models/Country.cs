using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class Country
    {
        public Country()
        {
            this.Users = new List<User>();
        }

        public int id { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
