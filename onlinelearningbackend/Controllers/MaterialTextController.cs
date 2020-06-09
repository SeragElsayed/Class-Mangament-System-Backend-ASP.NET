using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using onlinelearningbackend.Helpers;
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

        [HttpPost]
        [Route("api/course/addtextmaterial")]
       
        public IActionResult AddMaterial([FromForm] TextMaterial Material,IFormFile materialFile)
        {
          
                var file = materialFile;
                bool IsInfoValid = ModelState.IsValid;
                bool IsImageUploaded = file.Length > 0;

                if (IsInfoValid == false)
                {
                    return BadRequest(new { message = "invalid material info" });
                }
             
                var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
     
             
                var dbFilePath = FSHelpers.SaveMaterialText(uploadedfilename, file);
            if(dbFilePath == "exists")
            {
                return NotFound();
            }
            Material.TextMaterialName = uploadedfilename;
            Material.URL= dbFilePath;
            //Material.CourseId = 2;
        
            var result=db.AddMaterial(Material);
                

                return Ok(result);
            }
        [HttpGet]
        [Route ("api/materialtext/{CourseId}")]
        public IActionResult MaterialTextByCourseId(int CourseId)
        {
            if(CourseId==0)
            {
                BadRequest(new { Message = "invalid course id" });
            }
            var material = db.MaterialTextByCourseId(CourseId);
            if (material == null)
            {
                return NotFound();
            }
           
            return Ok(material);
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