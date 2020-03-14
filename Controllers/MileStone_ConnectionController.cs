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
    public class MileStone_ConnectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MileStone_ConnectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MileStone_Connection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MileStone_Connection>>> GetMileStone_Connection()
        {
            return await _context.MileStone_Connection.ToListAsync();
        }

        // GET: api/MileStone_Connection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MileStone_Connection>> GetMileStone_Connection(int id)
        {
            var mileStone_Connection = await _context.MileStone_Connection.FindAsync(id);

            if (mileStone_Connection == null)
            {
                return NotFound();
            }

            return mileStone_Connection;
        }

        // PUT: api/MileStone_Connection/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMileStone_Connection(int id, MileStone_Connection mileStone_Connection)
        {
            if (id != mileStone_Connection.ID)
            {
                return BadRequest();
            }

            _context.Entry(mileStone_Connection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MileStone_ConnectionExists(id))
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

        // POST: api/MileStone_Connection
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MileStone_Connection>> PostMileStone_Connection(MileStone_Connection mileStone_Connection)
        {
            _context.MileStone_Connection.Add(mileStone_Connection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMileStone_Connection", new { id = mileStone_Connection.ID }, mileStone_Connection);
        }

        // DELETE: api/MileStone_Connection/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MileStone_Connection>> DeleteMileStone_Connection(int id)
        {
            var mileStone_Connection = await _context.MileStone_Connection.FindAsync(id);
            if (mileStone_Connection == null)
            {
                return NotFound();
            }

            _context.MileStone_Connection.Remove(mileStone_Connection);
            await _context.SaveChangesAsync();

            return mileStone_Connection;
        }

        private bool MileStone_ConnectionExists(int id)
        {
            return _context.MileStone_Connection.Any(e => e.ID == id);
        }
    }
}
