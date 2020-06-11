using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.DAL;
using onlinelearningbackend.Helpers;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;

namespace onlinelearningbackend.Controllers
{
    //[Produces("application/json", "image/jpeg")]
    //[Route("api/[controller]")]
    [ApiController]
    public class CourseMaterialController : ControllerBase
    {
        private IWebHostEnvironment hostingEnvironment;
      
            ICourseMaterialManger CourseMaterialManager;
        public CourseMaterialController(ICourseMaterialManger _CMM, IWebHostEnvironment hostingEnvironment)
        {
            CourseMaterialManager = _CMM;
             this.hostingEnvironment = hostingEnvironment;

         }

            [HttpPost]
        [Route("api/course/addCourseMaterial/{CourseId}")]
        //////////////////////may cause error 
        public async Task<IActionResult> AddCourseMaterial( int CourseId,[FromForm] List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var uploader = new Uploader(hostingEnvironment);
            var AllMaterial = new List<CourseMaterialModel>();
            if (files.Count() == 0 || CourseId<=0)
                return BadRequest();
            foreach (IFormFile source in files)
            {
                if (source.Length == 0)
                    continue;
                //get uploaded file name as in the user pc
                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString().Trim('"');

                filename = uploader.EnsureCorrectFilename(filename);
                var PathToBeSavedInDB = uploader.GetPathAndFilename(filename);
                using (FileStream output = System.IO.File.Create(PathToBeSavedInDB))
                    await source.CopyToAsync(output);
               var cm= CourseMaterialManager.AddMaterial(CourseId, PathToBeSavedInDB).FirstOrDefault();
                AllMaterial.Add(cm);
            }


            return Ok(AllMaterial);


        }
        [HttpGet]
        [Route("api/course/DownloadCourseMaterial/{FileName}")]

        
        public async Task<IActionResult> DownloadCourseMaterial(string FileName)
        {

            var _Path = this.hostingEnvironment.WebRootPath + @"\uploads\"+FileName;
            var memory = new MemoryStream();
            using (var stream = new FileStream(_Path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(_Path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(_Path));


        }
        //for the file types only
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plain" },
                {".pdf","application/pdf" },
                {".jpg","image/jpeg" },
                {".jpeg","image/jpeg" },
                {".png","image/png" },
            };
        }
        [Authorize]
        [HttpGet]
        [Route("api/course/DeleteCourseMaterial/{FileName}")]

        ///needs to be reviewed

        public IActionResult DeleteCourseMaterial(string FileName)
        {

            var _Path = this.hostingEnvironment.WebRootPath + @"\uploads\" + FileName;

            if (_Path == null)
            {
                return NotFound();
            }
            else
            {
               
            System.IO.File.Delete(_Path);

            CourseMaterialManager.DeleteMaterialByPath(_Path);
            return Ok("file deleted");
            }



        }



    }
}
