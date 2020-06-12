﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;

namespace onlinelearningbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectManager ProjectManager;
        public ProjectController(IProjectManager _PM)
        {
            ProjectManager = _PM;
        }
        //IEnumerable<ProjectModel> GetProjectById(int ProjectId);
        [HttpGet]
        [Route("api/Project/Project/{ProjectId}")]
        public IActionResult GetProjectById(int ProjectId)
        {
            if (ProjectId < 1)
                return BadRequest();

            var Project = ProjectManager.GetProjectById(ProjectId);

            if (Project == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Project);
            }

        }
        //IEnumerable<ProjectModel> GetProjectByTrackId(int TrackId);

        [HttpGet]
        [Route("api/Project/Track/{TrackId}")]
        public IActionResult GetProjectByTrackId(int TrackId)
        {
            if (TrackId <1)
                return BadRequest();

            var Projects = ProjectManager.GetProjectByTrackId(TrackId);

            if (Projects == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Projects);
            }

        }

        //IEnumerable<ProjectModel> GetProjectByStudentId(int StudentId);
        [HttpGet]
        [Route("api/Project/Student/{StudentId}")]
        public IActionResult GetProjectByStudentId(int StudentId)
        {

            var Projects = ProjectManager.GetProjectByStudentId(StudentId);

            if (Projects == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Projects);
            }

        }
        //ProjectModel AddProject(ProjectModel NewProject, int TrackId);
        [HttpPost]
        [Route("api/Project/Add/{TrackId}")]
        public IActionResult AddProjectByTrackId([FromBody]ProjectModel NewProject,int TrackId)
        {
            if (ModelState.IsValid == false || TrackId < 1)
                return BadRequest();

            string StudentId = User.Claims.First(c => c.Type == "UserId").Value;

            var Project = ProjectManager.AddProjectByTrackId(NewProject,TrackId,StudentId);

            if (Project == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Project);
            }

        }
        //ProjectModel EditProject(ProjectModel EDitedProject);
        [HttpPost]
        [Route("api/Project/Edit")]
        public IActionResult EditProject([FromBody]ProjectModel EditedProject)
        {
            if (ModelState.IsValid == false )
                return BadRequest();

            var Project = ProjectManager.EditProject(EditedProject);

            if (Project == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Project);
            }

        }
        //void DeleteProject(int ProjectId);
        [HttpDelete]
        [Route("api/Project/Delete/{ProjectId}")]
        public IActionResult DeleteProject(int ProjectId)
        {
             ProjectManager.DeleteProject(ProjectId);
             return Ok();
        }
    }
}