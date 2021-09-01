
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideWebApi.Interfaces;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService emailService;
        public MailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] EmailRequest request)
        {
            try
            {
                await emailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
