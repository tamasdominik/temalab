using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.Models
{
    public class MileStone_Connection
    {
        public int ID { get; set; }
        public virtual ApplicationUser Profile { get; set; }
        public virtual MileStone MileStone_ID { get; set; }
        public bool Completed { get; set; }
    }
}
