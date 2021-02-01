using System;
using System.Collections.Generic;

#nullable disable

namespace comp2001asp.Models
{
    public partial class Session
    {
        public int UsersId { get; set; }
        public int SessionsId { get; set; }
        public DateTime LoginDate { get; set; }

        public virtual User Users { get; set; }
    }
}
