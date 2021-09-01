using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideWebApi.DTO;
using RideWebApi.Interfaces;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Controller
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingsController(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        /*[HttpGet]
        public async Task<ActionResult<List<BookingDto>>> GetAppusers()
        {
            var users = await _bookingRepository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn);


        }*/
    }
}
