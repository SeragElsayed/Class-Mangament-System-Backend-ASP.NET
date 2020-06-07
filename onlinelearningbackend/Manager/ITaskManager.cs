using System;
using System.Collections.Generic;
using onlinelearningbackend.Models;

namespace onlinelearningbackend.Manager
{
   public interface ITaskManager
    {
        TaskClass TaskByTaskId(int TaskId);
        IEnumerable<TaskClass> TaskByInstructorId(int InstructorId);
        IEnumerable<TaskClass> TaskByCourseId(int CourseId);
        /// taskclass
        IEnumerable<TaskClass> AddTask(TaskClass NewTask);
        IEnumerable<TaskClass> EditTask(TaskClass EditedTask);
        //void
        IEnumerable<TaskClass> DeleteTaskByTaskId(int TaskId);

    }
}
