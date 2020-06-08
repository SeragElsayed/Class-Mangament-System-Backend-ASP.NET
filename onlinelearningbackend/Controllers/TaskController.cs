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
        ITaskManager db;
        public TaskController(ITaskManager _db)
        {
            this.db = _db;     
        }
        [HttpPost]
        [Route("api/course/addmaterial")]
        //////////////////////may cause error 
        public IActionResult AddMaterial(TaskClass k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enter the whole data please");
            }

            return Ok(k);

        }
        [HttpPost]
        [Route("api/course/editmaterial")]
        //////////////////////may cause error 
        public IActionResult EditMaterial(TaskClass k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enter the whole data please");
            }

            return Ok(k);

        }
        [HttpGet]
        [Route("api/course/deletematerial/{MId}")]
        public IActionResult DeleteMaterialByMaterialId(int MId)
        {
            db.DeleteTaskByTaskId(MId);


            return Ok();

        }
        [HttpGet]
        [Route("api/course/tasksCrs/{id}")]
        public IActionResult TaskByCourseId(int id)
        {
            var tasks = db.TaskByCourseId(id);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }
        [HttpGet]
        [Route("api/course/tasksIns/{id}")]
        public IActionResult TaskByInstructorId(int id)
        {
            var tasks = db.TaskByCourseId(id);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }
        [HttpGet]
        [Route("api/course/tasksTas/{id}")]
        public IActionResult TaskByTaskId(int id)
        {
            var tasks = db.TaskByCourseId(id);
            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }
    }
}
