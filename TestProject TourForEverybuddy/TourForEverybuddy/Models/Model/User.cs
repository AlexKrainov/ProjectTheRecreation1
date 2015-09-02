using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class User
    {
        public User()
        {
            this.Tours = new List<Tour>();
            this.Tour_CommentOfTour = new List<Tour_CommentOfTour>();
            this.UserLanguages = new List<UserLanguage>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<byte> RouleId { get; set; }
        public Nullable<System.DateTime> DateRegister { get; set; }
        public Nullable<System.DateTime> LastAuthorization { get; set; }
        public string About { get; set; }
        public byte[] Photo { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
        public virtual ICollection<Tour_CommentOfTour> Tour_CommentOfTour { get; set; }
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
