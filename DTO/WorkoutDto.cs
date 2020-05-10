using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temalab_Fitness.Models;

namespace Temalab_Fitness.DTO
{
    public class WorkoutDto
    {

        public int Id { get; set; }
        public string WorkoutName { get; set; }
        public List<Exercise> Exercise { get; set; }

        public WorkoutDto(int id, string WorkoutName, List<Exercise> Exercise)
        {
            this.Id = id;
            this.WorkoutName = WorkoutName;
            this.Exercise = Exercise;
            
        }

        public WorkoutDto()
        {

        }
        public void addExercise(Exercise e)
        {
            Exercise.Add(e);
        }
    }
}
