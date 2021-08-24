using Microsoft.EntityFrameworkCore;
using RideWebApi.Interfaces;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RideContext _context;

        public BookingRepository(RideContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddBooking(Booking booking)
        {
            var result = await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteBooking(int bookingid)
        {
            var result = await _context.Booking
                .FirstOrDefaultAsync(e => e.Id == bookingid);
            if (result != null)
            {
                _context.Booking.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Booking> GetBooking(int bookingid)
        {
            return await _context.Booking.
                FirstOrDefaultAsync(e => e.Id == bookingid);
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _context.Booking.ToListAsync();
        }

        public Task<Booking> UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
