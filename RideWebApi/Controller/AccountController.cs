using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AccountController(RideContext context, ITokenService tokenService,IMapper mapper, IEmailService emailService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _emailService = emailService;
            _context = context;

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdto)
        {
            if (await UserExists(registerdto.Username)) return BadRequest("username is taken");
            var user = _mapper.Map<Appuser>(registerdto);
            using var hmac = new HMACSHA512();
            user.Username = registerdto.Username.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password));
            user.PasswordSalt = hmac.Key;
            

            _context.Appusers.Add(user);

            await _context.SaveChangesAsync();

            //sending email using Gmail SMTP
            using (var client=new SmtpClient())
            {
                client.Connect("smtp.gmail.com");
                client.Authenticate("nick96j@gmail.com", "manojdon");
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<p>you have been succefully registered to the RideOClock</p> <p>your username is :{registerdto.Username}</p><p>your password is :{registerdto.Password}</p> <p>dont forget your credentials details</p> <p> Enjoy your ride :)</p>",
                    TextBody = "<h4>welcome to the RideOCLok</h4> "
                };
                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress("Noreply", "nick96j@gmail.com"));
                message.To.Add(new MailboxAddress("Testing", registerdto.email));
                message.Subject = "Welcome to RideOClock";
                client.Send(message);
                client.Disconnect(true);
            }
            //TempData["Message"] = "Thank you for your service";

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
