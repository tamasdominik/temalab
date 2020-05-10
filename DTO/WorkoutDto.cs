using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.DTO
{
    public class WorkoutDto
    {

       
        public string WorkoutName { get; set; }
        public List<Exercise> Exercise { get; set; }

        public WorkoutDto( string WorkoutName, List<Exercise> Exercise)
        {
            this.WorkoutName = WorkoutName;
            this.Exercise = Exercise;
            
        }

        public WorkoutDto()
        {

        }
    }
}
