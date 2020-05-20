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
    public class ExercisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetExercise()
        {
            var exercises = _context.Exercise.Select(e=> new { e.Name, e.Difficulty,e.Set,e.Reps });
            return await exercises.ToListAsync();
        }

      
    }
}
