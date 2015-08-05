using System;
using System.Collections.Generic;

namespace TestCoockie.Models
{
    public partial class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Email { get; set; }
    }
}
