using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BorrowBikeWebApp;
using BorrowBikeWebApp.Models;

namespace BorrowBikeWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        
        private readonly BorrowBikeWebAppContext _context;
        
        public BikesController()
        {
            _context = new BorrowBikeWebAppContext();
        }

        // GET: api/Bikes
        [HttpGet]
        public IEnumerable<Bike> GetBikes()
        {
            return _context.Bikes;
        }

        
        // GET: api/Bikes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBike([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        // PUT: api/Bikes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBike([FromRoute] string id, [FromBody] Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bikeDB = await _context.Bikes.FindAsync(id);
            bikeDB.UserId = bike.UserId;
            bikeDB.User = await _context.Users.FindAsync(bike.UserId);

            if(bike.Status == "Available")
            {
                bikeDB.UserId = null;
            }

            bikeDB.Status = bike.Status;


            _context.Entry(bikeDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
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

        // POST: api/Bikes
        [HttpPost]
        public async Task<IActionResult> PostBike([FromBody] Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bikes.Add(bike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBike", new { id = bike.Id }, bike);
        }

        // DELETE: api/Bikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBike([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bike = await _context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            await _context.SaveChangesAsync();

            return Ok(bike);
        }

        private bool BikeExists(string id)
        {
            return _context.Bikes.Any(e => e.Id == id);
        }
        
    }
}