using System;
using System.Collections.Generic;

#nullable disable

namespace RideWebApi.Models
{
    public partial class Appuser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
