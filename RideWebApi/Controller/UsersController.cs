using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideWebApi.Data;
using RideWebApi.Models;

namespace RideWebApi.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsersController : BaseApiController
    {
        private readonly RideContext _context;

        public UsersController(RideContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Appuser>>> GetAppusers()
        {
            return await _context.Appusers.ToListAsync();
        }

        [Authorize]
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appuser>> GetAppuser(int id)
        {
            var appuser = await _context.Appusers.FindAsync(id);

            if (appuser == null)
            {
                return NotFound();
            }

            return appuser;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppuser(int id, Appuser appuser)
        {
            if (id != appuser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppuserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appuser>> PostAppuser(Appuser appuser)
        {
            _context.Appusers.Add(appuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppuser", new { id = appuser.Id }, appuser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppuser(int id)
        {
            var appuser = await _context.Appusers.FindAsync(id);
            if (appuser == null)
            {
                return NotFound();
            }

            _context.Appusers.Remove(appuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppuserExists(int id)
        {
            return _context.Appusers.Any(e => e.Id == id);
        }
    }
}
