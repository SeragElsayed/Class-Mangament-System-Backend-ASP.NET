using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Manager
{
   public interface ITaskSolutionManager
    {
        List<TaskSolution> TaskByStudent(int StudentId,int TaskId);

    }
}
