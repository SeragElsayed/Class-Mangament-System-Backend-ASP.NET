//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
//using onlinelearningbackend.Helpers;
//using onlinelearningbackend.Manager;
//using onlinelearningbackend.Models;

//namespace onlinelearningbackend.Controllers
//{
//    public class MaterialTextController : Controller
//    {
//        IMaterialTextManager db;
//        public MaterialTextController(IMaterialTextManager _db)
//        {
//            this.db = _db;
//        }

//        [HttpPost]
//        [Route("api/course/addtextmaterial")]
//        [Authorize]
//        public IActionResult AddMaterial([FromForm] TextMaterial Material )
//        {
          
//                var file = Request.Form.Files[0];
//                bool IsInfoValid = ModelState.IsValid;
//                bool IsImageUploaded = file.Length > 0;

//                if (IsInfoValid == false)
//                {
//                    return BadRequest(new { message = "invalid material info" });
//                }
             
//                var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
     
             
//                var dbFilePath = FSHelpers.SaveMaterialText(uploadedfilename, file);
//            if(dbFilePath == "exists")
//            {
//                return NotFound();
//            }
//            Material.TextMaterialName = uploadedfilename;
//            Material.URL= dbFilePath;
//            //Material.CourseId = 2;
        
//            var result=db.AddMaterial(Material);
                

//                return Ok(result);
//            }
//        [HttpGet]
//        [Route ("api/materialtext/{CourseId}")]
//        [Authorize]
//        [EnableCors]
//        public IActionResult MaterialTextByCourseId(int CourseId)
//        {
//            if(CourseId==0)
//            {
//                BadRequest(new { Message = "invalid course id" });
//            }
//            var material = db.MaterialTextByCourseId(CourseId);
//            if (material == null)
//            {
//                return NotFound();
//            }
           
//            return Ok(material);
//        }
//        [Authorize]
//        [HttpGet]
//        [Route("api/course/deletetextmaterial/{MId}")]
//        public IActionResult DeleteMaterialByMaterialId(int MId)
//        {
//            db.DeleteMaterialByMaterialId(MId);


//            return Ok();

//        }
//        [HttpGet]
//        [Route("api/material/getfile/{url}")]
//        [Authorize]
//        public byte[] DownloadAsync(string url)
//        {
//            string filePath = Directory.GetCurrentDirectory()+"\\Resources\\MaterialText\\"+url;
//            string fileName = url;
          
//             byte[] fileBytes = System.IO.File.ReadAllBytes(@"K:\iti 9 month program material\communication skills\Email Example.docx");
//           //var stream = new FileStream(filePath, FileMode.Open);
//            //return File(fileBytes, "application/force-download", fileName);
//            return fileBytes;














//        }
//    }}