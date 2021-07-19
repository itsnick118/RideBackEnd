using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideWebApi.Data;
using RideWebApi.DTO;
using RideWebApi.Interfaces;
using RideWebApi.Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RideWebApi.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AccountController : BaseApiController
    {
        private readonly RideContext _context;


        private readonly ITokenService _tokenService;

        public AccountController(RideContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdto)
        {
            if (await UserExists(registerdto.Username)) return BadRequest("username is taken");


            using var hmac = new HMACSHA512();

            var user = new Appuser
            {
                Username = registerdto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Appusers.Add(user);

            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };


        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logindto)
        {
            var user = await _context.Appusers.SingleOrDefaultAsync(x => x.Username == logindto.Username);

            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }
            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Appusers.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}
