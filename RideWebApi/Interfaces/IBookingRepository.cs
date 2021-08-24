using RideWebApi.DTO;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> GetBooking(int bookingid);
        Task<Booking> AddBooking(Booking booking);
        Task<Booking> UpdateBooking(Booking booking);
        void DeleteBooking(int bookingid);
       
    }
}
