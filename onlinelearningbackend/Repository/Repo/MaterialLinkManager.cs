using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Manager;
using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repository.Repo
{
    public class MaterialLinkManager : IMaterialLinkManager
    {
        ApplicationDbContext db;
        public MaterialLinkManager(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public void AddMaterial(int MId,string MName,string Url,int CrsId)
        {
            db.LinkMaterials.FromSqlRaw<LinkMaterial>($"usp_LinkMaterials_Insert {MId}{MName}{Url}{CrsId}");
        }

        public void DeleteMaterialByMaterialId(int MaterialId)
        {
            db.LinkMaterials.FromSqlRaw($"usp_LinkMaterials_Delete {MaterialId}");
        }

        public void EditMaterial(int MId, string MName, string Url, int CrsId)
        {
            db.LinkMaterials.FromSqlRaw<LinkMaterial>($"usp_LinkMaterials_Update {MId}{MName}{Url}{CrsId}");
        }

        public List<LinkMaterial> MaterialLinktByCourseId(int CourseId)
        {
            var materials = db.LinkMaterials.FromSqlRaw($"dbo.usp_LinkMaterials_CrsId {CourseId}").ToList();
            return materials;
        }
    }
}
