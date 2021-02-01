using System;
using System.Collections.Generic;

#nullable disable

namespace comp2001asp.Models
{
    public partial class User
    {
        public int UsersId { get; set; }
        public string UserForeName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
