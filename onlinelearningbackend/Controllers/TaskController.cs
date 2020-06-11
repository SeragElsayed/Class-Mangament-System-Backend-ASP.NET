using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Manager;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Controllers
{
    [Authorize]
    [ApiController]
    public class TaskController: ControllerBase
    {
        ITaskManager taskClass;
        public TaskController(ITaskManager _taskClass)
        {
            this.taskClass = _taskClass;     
        }
        [HttpPost]
        [Route("api/course/AddTask/{CourseId}")]
        //////////////////////may cause error 
        public IActionResult AddTaskByCourseId(int CourseId, TaskClass newTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enter the whole data please");
            }
            var addedtask = taskClass.AddTask( CourseId, newTask);
            return Ok(addedtask);

        }
        [HttpPut]
        [Route("api/course/edittask/{taskId}")]
        //////////////////////may cause error 
        public IActionResult EditTask(TaskClass EditedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enter the whole data please");
            }
            var editedTaskInDB = taskClass.EditTask(EditedTask);

            return Ok(editedTaskInDB);

        }
        [HttpDelete]
        [Route("api/course/deletetask/{taskId}")]
        public IActionResult DeleteTaskByTaskId(int taskId)
        {
            taskClass.DeleteTaskByTaskId(taskId);


            return Ok();

        }
        [HttpGet]
        [Route("api/course/tasks/{CourseId}")]
        public IActionResult GetTaskByCourseId(int CourseId)
        {
            var tasks = taskClass.GetTaskByCourseId(CourseId);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }
        //[HttpGet]
        //[Route("api/course/tasks/{InstructorId}")]
        //public IActionResult TaskByInstructorId(int InstructorId)
        //{
        //    //var InstructorFromToken=User.Claims
        //    var tasks = taskClass.TaskByCourseId(InstructorId);
        //    if (tasks == null)
        //        return NotFound();
        //    return Ok(tasks);
        //}
        [HttpGet]
        [Route("api/course/tasks/{TaskId}")]
        public IActionResult GetTaskByTaskId(int TaskId)
        {
            var tasks = taskClass.GetTaskByTaskId(TaskId);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }
    }
}
