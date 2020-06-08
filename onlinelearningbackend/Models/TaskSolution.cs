using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class TaskSolution
    {
        public int TaskSolutionId { get; set; }
        public string TaskSolutionURL { get; set; }
        public virtual MyUserModel MyUserModel { get; set; }
        public virtual Course Course { get; set; }
        public virtual TaskClass Task { get; set; }


    }
}
