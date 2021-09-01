using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RideWebApi.DTO;
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
        private readonly IMapper _mapper;

        public UserRepository(RideContext context, IMapper mapper)
        {
            _mapper = mapper;
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
        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Appusers
                .Where(x => x.Username == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Appusers
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Appuser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Add(Appuser user)
        {
            _context.Appusers.Add(user);
        }
    }
}
