using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.DTO
{
    public class MilestoneDTO
    {
        public string Name { get; set; }
        public int Counter { get; set; }
        public int Goal { get; set; }
        public MilestoneDTO()
        {

        }
        public MilestoneDTO(string name, int cnt, int goal)
        {
            Name = name;
            Counter = cnt;
            Goal = goal;
        }
        public void AddCounter(int x)
        {
            Counter += x;
        }
    }
}
