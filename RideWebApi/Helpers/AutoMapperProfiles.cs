using AutoMapper;
using RideWebApi.DTO;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Helpers
{

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Appuser, MemberDto>();
            CreateMap<RegisterDto, Appuser>();
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();
           
           
        }
    
    }
}
