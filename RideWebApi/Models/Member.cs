using System;
using System.Collections.Generic;

#nullable disable

namespace RideWebApi.Models
{
    public partial class Member
    {
        public int Memid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
