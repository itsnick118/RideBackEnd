using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Models
{
    [Table("Bookings")]
    public class Booking
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public DateTime startDate { get; set; }
        //public DateTime endDate { get; set; } = DateTime.Now;
        public string car { get; set; }
        public string cartype { get; set; }
        public Appuser Appuser { get; set; }
        public int AppuserId { get; set; }
    }
}
