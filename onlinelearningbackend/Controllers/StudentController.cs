using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Repository.IRepository;

namespace onlinelearningbackend.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        IStudentDB db;
        public StudentController(IStudentDB _db)
        {
            this.db = _db;
        }
     [HttpGet]
        [Authorize]
        [Route("api/student/crsid")]
        public IActionResult GetStudentByCrsId(int id)
        {
            var stds = db.GetStudentByCrsId(id);
            if(stds==null)
            { return NotFound(); }
            else
            {
                return Ok(stds);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("api/student/trackid")]
        public IActionResult GetStudentByTrackId(int id)
        {
            var stds = db.GetStudentByTrackId(id);
            if (stds == null)
            { return NotFound(); }
            else
            {
                return Ok(stds);
            }
        }
        [HttpGet]
        [Route("api/student/stdid")]
        [Authorize]
        public IActionResult GetStudentByStdId(int id)
        {
            var stds = db.GetStudentByStdId(id);
            if (stds == null)
            { return NotFound(); }
            else
            {
                return Ok(stds);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("api/student/tasks")]
        public IActionResult GetStdTaskBYCrsIdStdId(int crsid,int stdid)
        {
            var tasks = db.GetStdTaskBYCrsIdStdId(crsid,stdid);
            if (tasks == null)
            { return NotFound(); }
            else
            {
                return Ok(tasks);
            }
        }
    }
}