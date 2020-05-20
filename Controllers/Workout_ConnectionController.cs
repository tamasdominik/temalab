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
            List<Exercise> exes = new List<Exercise>();
            List<int> ids = new List<int>();
            List<string> woNames = new List<string>();
            List<WorkoutDto> result = new List<WorkoutDto>();
            foreach (var item in workouts)
            {
                if (!ids.Contains(item.id))
                {
                    if (ids.Count != 0)
                    {
                        result.Add(new WorkoutDto(ids.Last(), woNames.Last(), exes));
                    }
                    exes = new List<Exercise>();
                    ids.Add(item.id);
                    woNames.Add(item.WorkoutName);
                    exes.Add(item.Exercise);
                }
                else
                {
                    exes.Add(item.Exercise);
                }
            }
            result.Add(new WorkoutDto(ids.Last(), woNames.Last(), exes));

            return result;
        }


        // PUT: api/Workout_Connection/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutWorkout_Connection(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var workouts = await _context.Workout_Connection.Where(w => w.Workout_ID.ID == id).ToListAsync();
            for (int i = 0; i< workouts.Count; i++)
            {
                workouts[i].Counter++;
            }
            await _context.SaveChangesAsync();
            return Ok();
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
                    Exercise ex = _context.Exercise.Where(e => e.Name == workout.Exercise[i].Name).FirstOrDefault();

                    ctx.Workout_Connection.Add(new Workout_Connection()
                    {
                        Profile_ID = usr,
                        Workout_ID = wo,
                        Exercise = ex,
                    });
                }
                ctx.SaveChanges();
            }
            return Ok();
        }

        // DELETE: api/Workout_Connection/5
        [HttpDelete("{id}")]
        [Authorize]
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
    }
}
