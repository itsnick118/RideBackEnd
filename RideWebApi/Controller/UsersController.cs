using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideWebApi.Data;
using RideWebApi.DTO;
using RideWebApi.Extensions;
using RideWebApi.Interfaces;
using RideWebApi.Models;

namespace RideWebApi.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

     

        public UsersController(IUserRepository userRepository,IBookingRepository bookingRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAppusers()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);
        }

      
        // GET: api/Users/5
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetAppuser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            return _mapper.Map<MemberDto>(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppuser(int id, Appuser appuser)
        {
    
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appuser>> PostAppuser(Appuser appuser)
        {
            return CreatedAtAction("GetAppuser", new { id = appuser.Id }, appuser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppuser(int id)
        {
            return NoContent();
        }
        [AllowAnonymous]
        [HttpPost("add-booking")]
        public async Task<ActionResult<BookingDto>> AddBooking(Booking booking)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            var newbooking = await _bookingRepository.AddBooking(booking);
            user.Bookings.Add(newbooking);
            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
            return Ok(newbooking);
        }


    }
}
