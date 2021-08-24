using RideWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Services
{
    public class BookingService
    {
        private readonly RideContext _context;

        public BookingService(RideContext context)
        {
            _context = context;
        }
       // public void AddBooking ( Booking)
    }
}
