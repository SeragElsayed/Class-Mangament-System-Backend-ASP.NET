using System;
using System.Collections.Generic;
using System.Linq;
using onlinelearningbackend.Data;
using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Models;


namespace onlinelearningbackend.Manager
{
    public class MaterialTextManager : IMaterialTextManager
    {
        ApplicationDbContext DB;
        public MaterialTextManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public IEnumerable<TextMaterial> AddMaterial(TextMaterial NewMaterial)
        {
           var material=DB.TextMaterials.FromSqlRaw("dbo.usp_TextMaterials_Insert {0},{1}"
                                                , NewMaterial.TextMaterialName
                                                ,NewMaterial.URL
                                                )
                                            .ToList<TextMaterial>();
            return material;


        }

        public IEnumerable<TextMaterial> DeleteMaterialByMaterialId(int MaterialId)
        {
            var material = DB.TextMaterials.FromSqlRaw("dbo.usp_MatrialText_Delete {0}", MaterialId).ToList<TextMaterial>();
            return material;
        }

        public IEnumerable<TextMaterial> EditMaterial(TextMaterial EditMaterial)
        {
            var material = DB.TextMaterials.FromSqlRaw("dbo.usp_TextMaterials_Insert {0},{1},{2}"
                                                , EditMaterial.TextMaterialId
                                                , EditMaterial.TextMaterialName
                                                , EditMaterial.URL
                                                )
                                            .ToList<TextMaterial>();
            return material;
        }

        public IEnumerable<TextMaterial> MaterialTextByCourseId(int CourseId)
        {
            var material = DB.TextMaterials.FromSqlRaw("dbo.usp_MaterialText_Select_by_CourseId {0}", CourseId).ToList<TextMaterial>();
            return material;
        }
    }
}
