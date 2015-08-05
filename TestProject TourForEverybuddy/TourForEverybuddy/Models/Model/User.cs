using System;
using System.Collections.Generic;

namespace TourForEverybuddy.Models
{
    public partial class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<byte> RouleId { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> DateRegister { get; set; }
        public Nullable<System.DateTime> LastAuthorization { get; set; }
    }
}
