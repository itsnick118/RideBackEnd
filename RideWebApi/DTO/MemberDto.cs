using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.DTO
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string drivinglic { get; set; }
        public string address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
    }
}
