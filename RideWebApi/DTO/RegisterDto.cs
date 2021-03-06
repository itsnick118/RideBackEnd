using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName {get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string mobile { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string drivinglic { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
