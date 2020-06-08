using System;
using System.Collections.Generic;
using System.Linq;
using onlinelearningbackend.Data;
using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Models;

namespace onlinelearningbackend.Manager
{
    public class taskManager : ITaskManager
    {
        ApplicationDbContext DB;
        public taskManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public IEnumerable<TaskClass> AddTask(TaskClass NewTask)
        {
            var Tasks = DB.Tasks.FromSqlRaw("dbo.usp_Tasks_Insert {0},{1},{2}"
                                            , NewTask.TaskName
                                            , NewTask.Description
                                            , NewTask.DueDate

                                            ).ToList<TaskClass>();
            return Tasks;

            
        }

        public IEnumerable<TaskClass> DeleteTaskByTaskId(int TaskId)
        {
            var Tasks = DB.Tasks.FromSqlRaw("dbo.usp_Tasks_Delete {0}", TaskId).ToList<TaskClass>();
            return Tasks;
        }

        public IEnumerable<TaskClass> EditTask(TaskClass EditedTask)
        {
            var Tasks = DB.Tasks.FromSqlRaw("dbo.usp_Tasks_Insert {0},{1},{2}"
                                           , EditedTask.TaskId
                                           , EditedTask.TaskName
                                           , EditedTask.Description
                                           , EditedTask.DueDate

                                           ).ToList<TaskClass>();
            return Tasks;
        }

        public IEnumerable<TaskClass> TaskByCourseId(int CourseId)
        {
            var Tasks = DB.Tasks.FromSqlRaw("dbo.usp_Tasks_Select_by_Student_Id {0}", CourseId).ToList<TaskClass>();
            return Tasks;
        }

        public IEnumerable<TaskClass> TaskByInstructorId(int InstructorId)
        {
            var Tasks = DB.Tasks.FromSqlRaw("dbo.usp_Tasks_Select_by_Student_Id {0}", InstructorId).ToList<TaskClass>();
            return Tasks;
        }

        public TaskClass TaskByTaskId(int TaskId)
        {
            var Tasks = DB.Tasks.FromSqlRaw("dbo.usp_Tasks_Select_by_Student_Id {0}", TaskId).ToList<TaskClass>().FirstOrDefault();
            return Tasks;
        }
    }
}