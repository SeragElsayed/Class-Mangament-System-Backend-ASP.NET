using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Manager;
using onlinelearningbackend.Models;

namespace onlinelearningbackend.Controllers
{
    public class MaterialTextController : Controller
    {
        IMaterialTextManager db;
        public MaterialTextController(IMaterialTextManager _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("api/course/textmaterial/{id}")]
        public IActionResult MaterialLinktByCourseId(int id)
        {
            var links = db.MaterialTextByCourseId(id);
            if (links == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(links);
            }
        }
        [HttpPost]
        [Route("api/course/addtextmaterial")]
        /////////////////////////may cause error 
        public IActionResult AddMaterial(TextMaterial k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enter the whole data please");
            }

            return Ok(k);

        }
        [HttpPost]
        [Route("api/course/edittextmaterial")]
        ///////////////////////////////may cause error 
        public IActionResult EditMaterial(TextMaterial k)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enter the whole data please");
            }

            return Ok(k);

        }
        [HttpGet]
        [Route("api/course/deletetextmaterial/{MId}")]
        public IActionResult DeleteMaterialByMaterialId(int MId)
        {
            db.DeleteMaterialByMaterialId(MId);


            return Ok();

        }
    }
}