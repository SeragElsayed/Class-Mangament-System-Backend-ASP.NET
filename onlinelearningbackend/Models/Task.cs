using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class Task
    {

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public virtual ICollection<TaskSolution> TaskSolutions { get; set; } = new HashSet<TaskSolution>();

    }
}
