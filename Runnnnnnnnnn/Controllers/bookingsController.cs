using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Runnnnnnnnnn.Models;
using System.Web.Http.Cors;

namespace Runnnnnnnnnn.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class bookingsController : ApiController
    {
        private RideOClock4Entities db = new RideOClock4Entities();

        // GET: api/bookings
        public IQueryable<booking> Getbookings()
        {
            return db.bookings;
        }

        // GET: api/bookings/5
        [ResponseType(typeof(booking))]
        public IHttpActionResult Getbooking(int id)
        {
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbooking(int id, booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.id)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/bookings
        [ResponseType(typeof(booking))]
        public IHttpActionResult Postbooking(booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bookings.Add(booking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = booking.id }, booking);
        }

        // DELETE: api/bookings/5
        [ResponseType(typeof(booking))]
        public IHttpActionResult Deletebooking(int id)
        {
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.bookings.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bookingExists(int id)
        {
            return db.bookings.Count(e => e.id == id) > 0;
        }
    }
}