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

            var profile = await _context.Users.Where(p => p.Id == id).Select(pp => new { pp.Id, pp.Email, pp.UserName, pp.Gender, pp.DateOfBirth, pp.Height, pp.Weight }).FirstAsync();

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }
        
        
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutProfile( ApplicationUser profile)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id.ToString() != profile.Id)
            {
                return BadRequest();
            }

            ApplicationUser usr = _context.Users.Find(profile.Id);
            usr.Email = profile.Email;
            usr.UserName = profile.UserName;
            usr.Gender = profile.Gender;
            usr.DateOfBirth = profile.DateOfBirth;
            usr.Height = profile.Height;
            usr.Weight = profile.Weight;
            _context.SaveChanges();

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

    }
}
