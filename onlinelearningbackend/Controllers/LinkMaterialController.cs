using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Manager;

namespace onlinelearningbackend.Controllers
{
    public class LinkMaterialController : Controller
    {
        IMaterialLinkManager db;
        public LinkMaterialController(IMaterialLinkManager _db)
        {
            this.db = _db;
        }
        public IActionResult MaterialLinktByCourseId(int id)
        {
            var links = db.MaterialLinktByCourseId(id);
            if(links==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(links);
            }
        }
        public IActionResult AddMaterial(int MId, string MName, string Url, int CrsId)
        {
             db.AddMaterial(MId, MName, Url, CrsId);
         
                return Ok();
            
        }
        public IActionResult EditMaterial(int MId, string MName, string Url, int CrsId)
        {
            db.EditMaterial(MId, MName, Url, CrsId);

            return Ok();

        }
        public IActionResult DeleteMaterialByMaterialId(int MId)
        {
            db.DeleteMaterialByMaterialId(MId);
          

            return Ok();

        }
    }
}