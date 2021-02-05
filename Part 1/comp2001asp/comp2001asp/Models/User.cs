using System;
using System.Collections.Generic;

#nullable disable

namespace comp2001asp.Models
{
    public partial class User
    {
        public int Users_ID { get; set; }
        public string User_ForeName { get; set; }
        public string User_LastName { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
    }
}
