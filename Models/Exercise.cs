using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.Models
{
    public class Exercise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int Set { get; set; }
        public int Reps { get; set; }
    }
}
