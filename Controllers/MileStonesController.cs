using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Temalab_Fitness.Data;
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

            var ms3 =
                from ms in _context.MileStone_Connection
                join s in _context.Workout_Connection on ms.MileStone_ID.Name equals s.Exercise.Name
                where ms.Profile.Id == id
                orderby ms.MileStone_ID.ID
                select new { ms.MileStone_ID.Name, s.Counter, ms.MileStone_ID.Goal };

            return await ms3.ToListAsync();
        }

        //// GET: api/MileStones/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Object>> GetMileStone(int id)
        //{

        //    var ms3 =
        //        from ms in _context.MileStone_Connection
        //        join s in _context.Workout_Connection on ms.MileStone_ID.Name equals s.Exercise.Name
        //        where ms.Profile.Id == id.ToString()
        //        orderby ms.MileStone_ID.ID
        //        select new { ms.MileStone_ID.Name, s.Counter, ms.MileStone_ID.Goal };

        //    return await ms3.ToListAsync();
        //}

        // PUT: api/MileStones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMileStone(int id, MileStone mileStone)
        {
            if (id != mileStone.ID)
            {
                return BadRequest();
            }

            _context.Entry(mileStone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MileStoneExists(id))
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

        // POST: api/MileStones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MileStone>> PostMileStone(MileStone mileStone)
        {
            _context.MileStone.Add(mileStone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMileStone", new { id = mileStone.ID }, mileStone);
        }

        // DELETE: api/MileStones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MileStone>> DeleteMileStone(int id)
        {
            var mileStone = await _context.MileStone.FindAsync(id);
            if (mileStone == null)
            {
                return NotFound();
            }

            _context.MileStone.Remove(mileStone);
            await _context.SaveChangesAsync();

            return mileStone;
        }

        private bool MileStoneExists(int id)
        {
            return _context.MileStone.Any(e => e.ID == id);
        }
    }
}
