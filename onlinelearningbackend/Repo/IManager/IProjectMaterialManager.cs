using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
   public interface IProjectMaterialManager
    {
        IEnumerable<ProjectMaterialModel> AddMaterial(int courseId, string PathOnServer);
        IEnumerable<ProjectMaterialModel> DeleteMaterialByMaterialId(int MaterialId);
        IEnumerable<ProjectMaterialModel> DeleteMaterialByTrackId(int TrackId);
        IEnumerable<ProjectMaterialModel> GetMaterialByTrackId(int TrackId);
        IEnumerable<ProjectMaterialModel> GetMaterialById(int MaterialId);
        IEnumerable<ProjectMaterialModel> DeleteMaterialByPath(string PathOnServer);
    }
}
