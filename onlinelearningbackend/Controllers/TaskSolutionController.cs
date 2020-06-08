using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Manager;

namespace onlinelearningbackend.Controllers
{
    public class TaskSolutionController : Controller
    {
        ITaskSolutionManager db;
        public TaskSolutionController(ITaskSolutionManager _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("api/course/tasksStd/{StudentId}/{TaskId}")]
        ///////////////////////not sure of the route
        public IActionResult TaskByStudent(int StudentId, int TaskId)
        {
          var tasks=  db.TaskByStudent(StudentId, TaskId);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }
    }
}