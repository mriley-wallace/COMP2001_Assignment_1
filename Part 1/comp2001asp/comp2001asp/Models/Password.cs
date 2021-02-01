using System;
using System.Collections.Generic;

#nullable disable

namespace comp2001asp.Models
{
    public partial class Password
    {
        public int UsersId { get; set; }
        public string OldPassword { get; set; }
        public DateTime PChanged { get; set; }

        public virtual User Users { get; set; }
    }
}
