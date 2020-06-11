using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Manager
{
   public interface ITaskSolutionManager
    {
        TaskSolution GetTaskSolutionById(int TaskSolutionId);
        IEnumerable<TaskSolution> AddTaskByStudent(string StudentId,int TaskId, int CourseId, TaskSolution newTaskSolution);

        IEnumerable<TaskSolution> EditTaskSolution(string StudentId, TaskSolution newTaskSolution);
        IEnumerable<TaskSolution> DeleteTaskSolutionByTaskId(int TaskSolutionId);
    }
}
