using Microsoft.EntityFrameworkCore;
using RideWebApi.Interfaces;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly RideContext _context;

        public UserRepository(RideContext context)
        {
            _context = context;
        }

        public async Task<Appuser> GetUserByIdAsync(int id)
        {
            return await _context.Appusers.FindAsync(id);
        }
        public async Task<Appuser> GetUserByUsernameAsync(string username)
        {
            return await _context.Appusers.
                Include(p=>p.Bookings).
                SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<IEnumerable<Appuser>> GetUsersAsync()
        {
            return await _context.Appusers
                .Include(p => p.Bookings)
                .ToListAsync();
        }

        public Task<bool> SaveAllAync()
        {
            throw new NotImplementedException();
        }

        public void Update(Appuser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
