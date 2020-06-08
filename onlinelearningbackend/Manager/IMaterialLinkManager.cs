using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Manager
{
   public interface IMaterialLinkManager
    {
        IEnumerable<LinkMaterial> MaterialLinktByCourseId(int CourseId);
        IEnumerable<LinkMaterial> AddMaterial(LinkMaterial NewMaterial);
        IEnumerable<LinkMaterial> EditMaterial(LinkMaterial EditMaterial);
        IEnumerable<LinkMaterial> DeleteMaterialByMaterialId(int MaterialId);
    }
}
