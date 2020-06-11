using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
   public interface ICourseMaterialManger
    {
        IEnumerable<CourseMaterialModel> AddMaterial(int courseId, string PathOnServer);
        IEnumerable<CourseMaterialModel> DeleteMaterialByMaterialId(int MaterialId);
        IEnumerable<CourseMaterialModel> DeleteMaterialByCourseId(int courseId);
        IEnumerable<CourseMaterialModel> GetMaterialByCourseId(int CourseId);
        IEnumerable<CourseMaterialModel> GetMaterialById(int MaterialId);
        IEnumerable<CourseMaterialModel> DeleteMaterialByPath(string PathOnServer);
    }
}
