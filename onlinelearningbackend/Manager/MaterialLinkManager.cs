using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Manager
{
    public class MaterialLinkManager : IMaterialLinkManager
    {
        ApplicationDbContext DB;
        public MaterialLinkManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public IEnumerable<LinkMaterial> AddMaterial(LinkMaterial NewMaterial)
        {
            var material = DB.LinkMaterials.FromSqlRaw("dbo.usp_LinkMaterials_Insert {0},{1}"
                                               , NewMaterial.LinkMaterialName
                                               , NewMaterial.URL
                                               )
                                           .ToList<LinkMaterial>();
            return material;
        }

        public IEnumerable<LinkMaterial> DeleteMaterialByMaterialId(int MaterialId)
        {
            var material = DB.LinkMaterials.FromSqlRaw("dbo.usp_MatrialLink_Delete {0}", MaterialId).ToList<LinkMaterial>();
            return material;
        }

        public IEnumerable<LinkMaterial> EditMaterial(LinkMaterial EditMaterial)
        {
            var material = DB.LinkMaterials.FromSqlRaw("dbo.usp_LinkMaterials_Insert {0},{1},{2}"
                                               , EditMaterial.LinkMaterialId
                                              , EditMaterial.LinkMaterialName
                                              , EditMaterial.URL
                                              )
                                          .ToList<LinkMaterial>();
            return material;
        }

        public IEnumerable<LinkMaterial> MaterialLinktByCourseId(int CourseId)
        {
            var material = DB.LinkMaterials.FromSqlRaw("dbo.usp_MaterialLink_Select_by_CourseId {0}", CourseId).ToList<LinkMaterial>();
            return material;
        }
    }
}
