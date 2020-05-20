using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Temalab_Fitness.Data;
using Temalab_Fitness.DTO;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MileStonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MileStonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MileStones
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Object>> GetMileStone()
        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var milestones =
                from ms in _context.MileStone_Connection
                join s in _context.Workout_Connection on ms.MileStone_ID.Name equals s.Exercise.Name
                where ms.Profile.Id == id
                orderby ms.MileStone_ID.ID
                select new { ms.MileStone_ID.Name, s.Counter, ms.MileStone_ID.Goal };
            var mileStones = await milestones.ToListAsync();
            var exercises = new List<string>();
            var result = new List<MilestoneDTO>();
            foreach (var item in mileStones)
            {
                if (!exercises.Contains(item.Name))
                {
                    result.Add(new MilestoneDTO(item.Name, item.Counter, item.Goal));
                    exercises.Add(item.Name);
                }
                else
                {
                    MilestoneDTO ms = result.Where(m => m.Name == item.Name).First();
                    ms.AddCounter(item.Counter);
                }
            }
            return result;
        }


    }
}
