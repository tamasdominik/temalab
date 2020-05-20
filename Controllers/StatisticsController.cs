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

            var stats = await _context.Workout_Connection.Where(s => s.Profile_ID.Id == id).Select(s => new { s.Exercise.Name, Counter = s.Counter * s.Exercise.Set * s.Exercise.Reps, burntcalories = (s.Exercise.Difficulty * s.Profile_ID.Height * s.Profile_ID.Weight) / 500 }).ToListAsync();

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

      
    }
}
