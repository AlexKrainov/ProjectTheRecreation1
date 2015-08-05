using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourForEverybuddy.Models.Model
{
    [MetadataType(typeof(UserMetaDate))]
    public partial class User
    {
    }

    public class UserMetaDate
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<byte> RouleId { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> DateRegister { get; set; }
        public Nullable<System.DateTime> LastAuthorization { get; set; }
    }

}