#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TBS.Models;

namespace TBS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiBookingsController : ControllerBase
    {
        private readonly BookingContext _context;

        public TaxiBookingsController(BookingContext context)
        {
            _context = context;
        }

        // GET: api/TaxiBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxiBooking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/TaxiBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiBooking>> GetTaxiBooking(long id)
        {
            var taxiBooking = await _context.Bookings.FindAsync(id);

            if (taxiBooking == null)
            {
                return NotFound();
            }

            return taxiBooking;
        }

        // PUT: api/TaxiBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxiBooking(long id, TaxiBooking taxiBooking)
        {
            
            if (id != taxiBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxiBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiBookingExists(id))
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

        // POST: api/TaxiBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxiBooking>> PostTaxiBooking(TaxiBooking taxiBooking)
        {
            _context.Bookings.Add(taxiBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxiBooking", new { id = taxiBooking.Id }, taxiBooking);
        }

        // DELETE: api/TaxiBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxiBooking(long id)
        {
            var taxiBooking = await _context.Bookings.FindAsync(id);
            if (taxiBooking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(taxiBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxiBookingExists(long id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
