using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Manager
{
    interface ITaskSolutionManager
    {
        void TaskByStudent(int StudentId,int TaskId);

    }
}
