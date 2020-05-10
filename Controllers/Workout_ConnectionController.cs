using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetWorkout_Connection()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var workouts = await _context.Workout_Connection.Where(w => w.Profile_ID.Id == id).Select(w => new {id = w.Workout_ID.ID, WorkoutName = w.Workout_ID.Name, Exercise = w.Exercise }).ToListAsync();

            if (workouts == null)
                return NotFound();

            var grouppedWorkouts = workouts.GroupBy(w =>w.WorkoutName, w => new { w.Exercise, w.id }, ( key, g) => new WorkoutDto(key, g.ToList()));

            return grouppedWorkouts.ToList();
        }

        // GET: api/Workout_Connection/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<WorkoutDto>>> GetWorkout_Connection(int id)
        //{
        //    var workouts = _context.Workout_Connection.Where(w => w.Profile_ID.Id == id).Select(w => new { WorkoutName = w.Workout_ID.Name, Exercise = w.Exercise }).ToList();

        //    if (workouts == null)
        //        return NotFound();

        //    var grouppedWorkouts = workouts.GroupBy(w => w.WorkoutName, w => w.Exercise, (key, g) => new WorkoutDto(key, g.ToList()));

        //    return grouppedWorkouts.ToList();
        //}

        // PUT: api/Workout_Connection/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutWorkout_Connection(Workout_Connection workout_Connection)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id != workout_Connection.ID.ToString())
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
                return NotFound();
            }
        
            return NoContent();
        }

        // POST: api/Workout_Connection
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Workout_Connection>> PostWorkout_Connection([FromBody]WorkoutDto workout)
        {

            using (var ctx = _context)
            {
                var wo = new Workout();
                wo.Name = workout.WorkoutName;

                ctx.Workout.Add(wo);

                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser usr = _context.Users.Find(id);

                for (int i = 0; i < workout.Exercise.Count; i++)
                {
                    ctx.Workout_Connection.Add(new Workout_Connection()
                    {
                        Profile_ID = usr,
                        Workout_ID = wo,
                        Exercise = workout.Exercise[i]
                    });
                }
                ctx.SaveChanges();
            }
            return Ok();
        }

        // DELETE: api/Workout_Connection/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Workout_Connection>> DeleteWorkout_Connection(int id)
        {

            using (var ctx = _context)
            {
                var wo = ctx.Workout_Connection.Where(w => w.Workout_ID.ID == id);
                foreach (var i in wo)
                {
                    ctx.Workout_Connection.Remove(i);
                }

                ctx.Workout.Remove(ctx.Workout.FirstOrDefault(e => e.ID == id));
                ctx.SaveChanges();
            }
            return Ok();

        }
        private bool Workout_ConnectionExists(int id)
        {
            return _context.Workout_Connection.Any(e => e.ID == id);
        }
    }
}
