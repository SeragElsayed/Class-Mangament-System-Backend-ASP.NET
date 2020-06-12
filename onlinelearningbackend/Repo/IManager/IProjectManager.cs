using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
   public interface IProjectManager
    {
        IEnumerable<ProjectModel> GetProjectById(int ProjectId);
        IEnumerable<ProjectModel> GetProjectByTrackId(int TrackId);
        IEnumerable<ProjectModel> GetProjectByStudentId(int StudentId);
        ProjectModel AddProjectByTrackId(ProjectModel NewProject,int TrackId, string StudentId);
        ProjectModel EditProject(ProjectModel EDitedProject);
        void DeleteProject(int ProjectId);

    }
}
