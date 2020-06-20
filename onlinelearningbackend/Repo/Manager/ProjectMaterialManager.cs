using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.Manager
{
    public class ProjectMaterialManager : IProjectMaterialManager
    {
        ApplicationDbContext DB;
        public ProjectMaterialManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        ///add material 
        public IEnumerable<ProjectMaterialModel> AddMaterial(int ProjectId, string PathOnServer)
        {
            var material = DB.ProjectMaterialModels.FromSqlRaw<ProjectMaterialModel>
                ($"EXEC dbo.usp_ProjectMaterialModel_Insert '{PathOnServer}',{ProjectId}").ToList<ProjectMaterialModel>();
            return material;
        }

        ///delete material by material id

        public IEnumerable<ProjectMaterialModel> DeleteMaterialByMaterialId(int MaterialId)
        {
            var material = DB.ProjectMaterialModels.FromSqlRaw<ProjectMaterialModel>
                ($"EXEC dbo.usp_ProjectMaterialModel_DeleteById {MaterialId}");
            return material;
        }
        ///delete material by course id
        public IEnumerable<ProjectMaterialModel> DeleteMaterialByTrackId(int ProjectId)
        {
            var material = DB.ProjectMaterialModels.FromSqlRaw<ProjectMaterialModel>
                ($"EXEC dbo.usp_ProjectMaterialModel_DeleteByProjectId {ProjectId}");
            return material;
        }



        /// get material by course id 

        public IEnumerable<ProjectMaterialModel> GetMaterialByTrackId(int ProjectId)
        {
            var material = DB.ProjectMaterialModels.FromSqlRaw<ProjectMaterialModel>
                ($"EXEC dbo.usp_ProjectMaterialModel_SelectByProjectIdId {ProjectId}");
            return material;
        }
        /// get material by material id 
        /// not important
        public IEnumerable<ProjectMaterialModel> GetMaterialById(int materialId)
        {
            var material = DB.ProjectMaterialModels.FromSqlRaw<ProjectMaterialModel>
                ($"EXEC dbo.usp_ProjectMaterialModel_Select {materialId}");
            return material;
        }


        public IEnumerable<ProjectMaterialModel> DeleteMaterialByPath(string PathOnServer)
        {
            var material = DB.ProjectMaterialModels.FromSqlRaw<ProjectMaterialModel>
                ($"EXEC dbo.usp_ProjectMaterialModel_DeletePath {PathOnServer}");
            return material;
        }
    }
}
