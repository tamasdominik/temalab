using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
