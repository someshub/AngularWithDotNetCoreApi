using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarkController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<Landmarks> Get()
        //{
        //    
        //    return Enumerable<Landmarks>();
        //    {

        //    })
        //    .ToArray();
        //}

        private readonly APIDBContext _context;

        public LandmarkController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/Landmarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Landmark>>> GetLandmarks()
        {
            return await _context.landmarks.ToListAsync();
        }

        // GET: api/Landmarks/5
        [HttpGet("{id}")]
      
        public async Task<ActionResult<Landmark>> GetLandmarks(int id)
        {
            var bank = await _context.landmarks.FindAsync(id);

            if (bank == null)
            {
                return NotFound();
            }

            return bank;
        }

        // PUT: api/Landmarks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandmarks(int id, Landmark landmarks)
        {
            if (id != landmarks.Landmark_Id)
            {
                return BadRequest();
            }

            _context.Entry(landmarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandmarksExists(id))
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

        // POST: api/Landmarks
        [HttpPost]
       
        public async Task<ActionResult<Landmark>> PostLandmarks(Landmark landmarks)
        {
            _context.landmarks.Add(landmarks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLandmarks", new { id = landmarks.Landmark_Id }, landmarks);
        }

        // DELETE: api/Landmarks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Landmark>> DeleteLandmark(int id)
        {
            var bank = await _context.landmarks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }

            _context.landmarks.Remove(bank);
            await _context.SaveChangesAsync();

            return bank;
        }

        private bool LandmarksExists(int id)
        {
            return _context.landmarks.Any(e => e.Landmark_Id == id);
        }
    }
}
