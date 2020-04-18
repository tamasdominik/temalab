using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Temalab_Fitness.Data;
using Temalab_Fitness.DTO;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Workout_ConnectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
         
        public Workout_ConnectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Workout_Connection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetWorkout_Connection()
        {
            var workouts = _context.Workout_Connection.Select(w => new {w.Profile_ID.UserName, WorkoutName = w.Workout_ID.Name, ExerciseName= w.Exercise.Name, w.Exercise.Difficulty, w.Exercise.Set, w.Exercise.Reps});
            return await workouts.ToListAsync();
        }

        // GET: api/Workout_Connection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetWorkout_Connection(int id)
        {
            var workouts = _context.Workout_Connection.Where(w => w.Profile_ID.ID == id).Select(w => new { WorkoutName = w.Workout_ID.Name, Exercise = w.Exercise }).ToList();

            if (workouts == null)
                return NotFound();

            var grouppedWorkouts = workouts.GroupBy(w => w.WorkoutName, w => w.Exercise, (key, g) => new WorkoutDto(key, g.ToList()));

            return grouppedWorkouts.ToList();
        }

        // PUT: api/Workout_Connection/5
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

        // POST: api/Workout_Connection
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Workout_Connection>> PostWorkout_Connection(Workout_Connection workout_Connection)
        {
            _context.Workout_Connection.Add(workout_Connection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout_Connection", new { id = workout_Connection.ID }, workout_Connection);
        }

        // DELETE: api/Workout_Connection/5
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
