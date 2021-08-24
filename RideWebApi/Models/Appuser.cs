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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string drivinglic { get; set; }
        public string address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
