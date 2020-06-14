using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Magnum.FileSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using onlinelearningbackend.Helpers;
using onlinelearningbackend.Manager;
using onlinelearningbackend.Models;

namespace onlinelearningbackend.Controllers
{
    //[Authorize]
    [ApiController]
    public class TaskSolutionController : ControllerBase
    {
       // ITaskSolutionManager db;
         ITaskSolutionManager TaskSolutionManager;
        public TaskSolutionController(ITaskSolutionManager _TSM)
        {
            this.TaskSolutionManager = _TSM;
        }
        [HttpGet]
        [Route("api/course/tasksStd/{tasksolutionId}")]
        public IActionResult GetTaskSolutionById(int TaskSolutionId)
        {
           var taskSolution= TaskSolutionManager.GetTaskSolutionById(TaskSolutionId);
            //after geeting the task solution from DB 
            //exctract the task solution url from the object
            var FilePathOnServer = taskSolution.TaskSolutionURL;
            //return the file in that url path to the user
            return Ok();
        }


        //[HttpPost]
        //[Route("api/course/tasksStd/{StudentId}/{TaskId}/{CourseId}")]
        /////////////////////////not sure of the route
        //public IActionResult AddTaskSolutionByStudent(int TaskId, int CourseId, TaskSolution newTaskSolution,string StudentId,[FromForm]Microsoft.AspNetCore.Http.IFormFile Files)
        //{
        //    var file = Request.Form.Files[0];
        //    //bool IsInfoValid = ModelState.IsValid;
        //    bool IsFileUploaded = file.Length > 0;

        //    // string StudentID = User.Claims.First(c => c.Type == "UserId").Value;
        //    bool IsInfoValid = TaskId > 0 && CourseId > 0;// && StudentID !=null  ;

        //    if(IsInfoValid== false || IsFileUploaded == false)
        //    {
        //        return BadRequest(new { message = "Info is not valid " });
        //    }
        //    //check if file extensipon allowed
        //    var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

        //    var IsFileExtAllowed = FSHelpers.IsFileAllowed(uploadedfilename);
        //    if (IsFileExtAllowed == false)
        //    {
        //        return BadRequest(new { message = "file extensions allowed are rar and zip only " });

        //    }
        //    //save the file on the server 
        //    //return path of the saved file
        //    var DBFileUrl = FSHelpers.SaveTaskSolutionFile(uploadedfilename, file);
        //    // newtask.TaskSolutionURL=returned file path
        //    newTaskSolution.TaskSolutionURL = DBFileUrl;
        //   // var TaskSolution =  TaskSolutionManager.AddTaskByStudent(StudentID,TaskId, CourseId, newTaskSolution);
        //    var TaskSolution =  TaskSolutionManager.AddTaskByStudent(StudentId,TaskId, CourseId, newTaskSolution);

        //    if (TaskSolution == null)
        //    {
        //        return NotFound();

        //    }
        //    return Ok(TaskSolution);
        //    }
        ///////
        [HttpPost]
        [Route("api/course/tasksStd/{StudentId}/{TaskId}/{CourseId}")]
        ///////////////////////not sure of the route
        public IActionResult AddTaskSolutionByStudent(string StudentId, int TaskId, int CourseId, List<IFormFile> Files)
        {
            var file = Files[0];
            //bool IsInfoValid = ModelState.IsValid;
            bool IsFileUploaded = file.Length > 0;

            //string StudentID = User.Claims.First(c => c.Type == "UserId").Value;
            string StudentID = StudentId;

            bool IsInfoValid = TaskId > 0 && CourseId > 0 && StudentID != null;

            if (IsInfoValid == false || IsFileUploaded == false)
            {
                return BadRequest(new { message = "Info is not valid " });
            }
            //check if file extensipon allowed
            var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            var IsFileExtAllowed = FSHelpers.IsFileAllowed(uploadedfilename);
            if (IsFileExtAllowed == false)
            {
                return BadRequest(new { message = "file extensions allowed are rar and zip only " });

            }
            //save the file on the server 
            //return path of the saved file
            var DBFileUrl = FSHelpers.SaveTaskSolutionFile(uploadedfilename, file);
            // newtask.TaskSolutionURL=returned file path
            var newTaskSolution = new TaskSolution() { TaskSolutionURL = DBFileUrl };
            //newTaskSolution.TaskSolutionURL = DBFileUrl;
            var TaskSolution = TaskSolutionManager.AddTaskByStudent(StudentID, TaskId, CourseId, newTaskSolution);

            if (TaskSolution == null)
            {
                return NotFound();

            }
            return Ok(TaskSolution);
        }


        [HttpGet]
        [Route("api/course/tasksStd/{StudentId}/{TaskId}/{CourseId}")]
        public IActionResult EditTaskSolutionByStudent( TaskSolution newTaskSolution )
        {
            var file = Request.Form.Files[0];

            bool IsFileUploaded = file.Length > 0;

            string StudentID = User.Claims.First(c => c.Type == "UserId").Value;

            if ( IsFileUploaded == false)
            {
                return BadRequest(new { message = "Info is not valid " });
            }
            //check if file extensipon allowed
            var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            var IsFileExtAllowed = FSHelpers.IsFileAllowed(uploadedfilename);
            if (IsFileExtAllowed == false)
            {
                return BadRequest(new { message = "file extensions allowed are rar and zip only " });

            }
            
            var DBFileUrl = FSHelpers.SaveTaskSolutionFile(uploadedfilename, file);

            newTaskSolution.TaskSolutionURL = DBFileUrl;
            var OldPathFile = newTaskSolution.TaskSolutionURL;
            var TaskSolution = TaskSolutionManager.EditTaskSolution(StudentID, newTaskSolution);

            if (TaskSolution == null)
            {
                return NotFound();

            }

            FSHelpers.DeleteOldTaskSolutionFile(OldPathFile);

            return Ok(TaskSolution);
        }


        [Route("api/course/tasksStd/{TaskSolutionId}")]
        [HttpDelete("{TaskSolutionId}")]
        public IActionResult DeleteTaskSolutionByTaskId(int TaskSolutionId)
        {
            TaskSolutionManager.DeleteTaskSolutionByTaskId(TaskSolutionId);
            return Ok();
        }


        [HttpPost]
        [Route("api/getfile/{TaskSolutionId}")]
        public HttpResponseMessage GetFileForInstructor(int TaskSolutionId)
        {
            var tasksolution = TaskSolutionManager.GetTaskSolutionById(TaskSolutionId);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(tasksolution.TaskSolutionURL,FileMode.Open);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("Resources/Download Files");

            return response;
        }

       
    }
    }
