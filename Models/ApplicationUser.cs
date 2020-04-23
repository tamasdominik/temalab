using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.Models
{
    public class ApplicationUser : IdentityUser
    {
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
