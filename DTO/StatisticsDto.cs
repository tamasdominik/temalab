using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.DTO
{
    public class StatisticsDto
    {
        public string name { get; set; }
        public int counter { get; set; }
        public int burntcalories { get; set; }

        public StatisticsDto()
        {

        }

        public StatisticsDto(string name, int counter, int burntcalories)
        {
            this.name = name;
            this.counter = counter;
            this.burntcalories = burntcalories;
        }
    }
}
