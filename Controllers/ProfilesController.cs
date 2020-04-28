using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Temalab_Fitness.Data;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.Controllers
{
    [Route("api/Profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        
        // GET: api/Profiles

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Object>> GetProfile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var profile = _context.Users.Where(p => p.Id == id).Select(pp => new { pp.Id, pp.Email, pp.UserName, pp.Gender, pp.DateOfBirth, pp.Height, pp.Weight }).First();

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }
        
        // GET: api/Profiles/5
        //[HttpGet]
        //public async Task<ActionResult<Object>> GetProfile()
        //{
        //    var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var profile =  _context.Users.Where(p => p.Id == userid).Select(pp => pp.UserName).First();

        //    if (profile == null)
        //    {
        //        return NotFound();
        //    }

        //    return profile;
        //}

        // PUT: api/Profiles/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for
         // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.ID)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profiles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            _context.Profile.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.ID }, profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteProfile(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ID == id);
        }
    }
}
