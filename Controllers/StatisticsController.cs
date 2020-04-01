using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Temalab_Fitness.Data;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Statistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetWorkout_Connection()
        {
            var statistics = _context.Workout_Connection.Select(s=> new { s.Exercise.Name, s.Counter, burntcalories = (s.Exercise.Difficulty * s.Profile_ID.Height * s.Profile_ID.Weight * s.Counter) / 500 });
            return await statistics.ToListAsync();
        }

        // GET: api/Statistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetWorkout_Connection(int id)
        {
            var stats = _context.Workout_Connection.Where(s=>s.Profile_ID.ID ==id).Select(s=> new {s.Exercise.Name, s.Counter, burntcalories = (s.Exercise.Difficulty * s.Profile_ID.Height * s.Profile_ID.Weight * s.Counter) / 500 });

            if (stats == null)
            {
                return NotFound();
            }

            return await stats.ToListAsync();
        }

        // PUT: api/Statistics/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout_Connection(int id, Workout_Connection workout_Connection)
        {
            if (id != workout_Connection.ID)
            {
                return BadRequest();
            }

            _context.Entry(workout_Connection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Workout_ConnectionExists(id))
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

        // POST: api/Statistics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Workout_Connection>> PostWorkout_Connection(Workout_Connection workout_Connection)
        {
            _context.Workout_Connection.Add(workout_Connection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout_Connection", new { id = workout_Connection.ID }, workout_Connection);
        }

        // DELETE: api/Statistics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Workout_Connection>> DeleteWorkout_Connection(int id)
        {
            var workout_Connection = await _context.Workout_Connection.FindAsync(id);
            if (workout_Connection == null)
            {
                return NotFound();
            }

            _context.Workout_Connection.Remove(workout_Connection);
            await _context.SaveChangesAsync();

            return workout_Connection;
        }

        private bool Workout_ConnectionExists(int id)
        {
            return _context.Workout_Connection.Any(e => e.ID == id);
        }
    }
}
