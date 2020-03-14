using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.Models
{
    public class Workout_Connection
    {
        public int ID { get; set; }
        public virtual Profile Profile_ID { get; set; }
        public virtual Workout Workout_ID { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int Counter { get; set; }
    }
}
