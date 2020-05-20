using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Temalab_Fitness.Data;
using Temalab_Fitness.DTO;
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
        [Authorize]
        public async Task<ActionResult<Object>> GetWorkout_Connection()
        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var stats = _context.Workout_Connection.Where(s => s.Profile_ID.Id == id).Select(s => new { s.Exercise.Name, Counter = s.Counter * s.Exercise.Set * s.Exercise.Reps, burntcalories = (s.Exercise.Difficulty * s.Profile_ID.Height * s.Profile_ID.Weight) / 500 }).ToList();

            if (stats == null)
            {
                return NotFound();
            }

            List<string> exerciseNames = new List<string>();
            List<int> calories = new List<int>();
            List<int> counter = new List<int>();
            foreach (var item in stats)
            {
                if (!exerciseNames.Contains(item.Name))
                {
                    exerciseNames.Add(item.Name);
                    calories.Add(item.burntcalories);
                    counter.Add(item.Counter);
                }
                else
                {
                    int index = exerciseNames.IndexOf(item.Name);
                    counter[index] += item.Counter; 
                }
            }
            List<StatisticsDto> result = new List<StatisticsDto>();
            for (int i = 0; i < exerciseNames.Count; i++)
            {
                result.Add(new StatisticsDto(exerciseNames[i], counter[i], calories[i]*counter[i]));
            }

            return result;
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
