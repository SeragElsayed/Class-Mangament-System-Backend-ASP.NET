using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Manager
{
    public class TaskSolutionManager : ITaskSolutionManager
    {
        ApplicationDbContext DB;
        public TaskSolutionManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public List<TaskSolution> TaskByStudent(int StudentId, int TaskId)
        {

         var tasks=   DB.TaskSolutions.FromSqlRaw("EXEC dbo.usp_CourseMyUserModel_Insert {0}", StudentId, TaskId).ToList<TaskSolution>();
            return tasks;
        
        }
    }
}
