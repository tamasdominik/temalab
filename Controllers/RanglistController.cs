using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Temalab_Fitness.Data;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RanglistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RanglistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ranglist
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Object>>> GetWorkout_Connection()
        {
            var ranglist = await _context.Workout_Connection.Select(r => new { r.Profile_ID.UserName, burntCalories = (r.Exercise.Difficulty * r.Profile_ID.Height * r.Profile_ID.Weight * r.Counter * r.Exercise.Reps * r.Exercise.Set) / 500 }).Distinct().ToListAsync();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (var item in ranglist)
            {
                if (!keyValuePairs.ContainsKey(item.UserName))
                {
                    keyValuePairs.Add(item.UserName, item.burntCalories);
                }
                else
                {
                    keyValuePairs[item.UserName] += item.burntCalories;
                }
            }

            return keyValuePairs.Select(k => new { UserName = k.Key, burntCalories = k.Value }).ToList();
        }

    }
}
