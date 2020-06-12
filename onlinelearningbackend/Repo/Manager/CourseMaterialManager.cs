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
    public class CourseMaterialManager : ICourseMaterialManger
    {
        ApplicationDbContext DB;
        public CourseMaterialManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        ///add material 
        public IEnumerable<CourseMaterialModel> AddMaterial(int courseId, string PathOnServer)
        {
            var material = DB.CourseMaterialModels.FromSqlRaw<CourseMaterialModel>
                ($"EXEC dbo.usp_CourseMaterialModel_Insert '{PathOnServer}',{courseId}");
            return material;
        }

        ///delete material by material id

        public IEnumerable<CourseMaterialModel> DeleteMaterialByMaterialId(int MaterialId)
        {
            var material = DB.CourseMaterialModels.FromSqlRaw<CourseMaterialModel>
                ($"EXEC dbo.usp_CourseMaterialModel_DeleteById {MaterialId}");
            return material;
        }
        ///delete material by course id
        public IEnumerable<CourseMaterialModel> DeleteMaterialByCourseId(int courseId)
        {
            var material = DB.CourseMaterialModels.FromSqlRaw<CourseMaterialModel>
                ($"EXEC dbo.usp_CourseMaterialModel_DeleteByCourseId {courseId}");
            return material;
        }



        /// get material by course id 

        public IEnumerable<CourseMaterialModel> GetMaterialByCourseId(int CourseId)
        {
            var material = DB.CourseMaterialModels.FromSqlRaw<CourseMaterialModel>
                ($"EXEC dbo.usp_CourseMaterialModel_SelectByCourseId {CourseId}");
            return material;
        }
        /// get material by material id 
        /// not important
        public IEnumerable<CourseMaterialModel> GetMaterialById(int materialId)
        {
            var material = DB.CourseMaterialModels.FromSqlRaw<CourseMaterialModel>
                ($"EXEC dbo.usp_CourseMaterialModel_Select {materialId}");
            return material;
        }


        public IEnumerable<CourseMaterialModel> DeleteMaterialByPath(string PathOnServer)
        {
            var material = DB.CourseMaterialModels.FromSqlRaw<CourseMaterialModel>
                ($"EXEC dbo.usp_CourseMaterialModel_DeletePath {PathOnServer}");
            return material;
        }
    }
}