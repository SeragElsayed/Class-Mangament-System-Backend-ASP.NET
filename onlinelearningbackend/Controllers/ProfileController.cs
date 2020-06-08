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
    public class ProfileController : Controller
    {
        IProfile db;
        public ProfileController(IProfile _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Authorize]
        [Route("api/user/profilecourses")]
        public IActionResult GetStdCrs(int id)
        {
            var crs = db.GetStdCrsByStdId(id);
            if(crs==null)
            { return NotFound(); }
            else
            { return Ok(crs); }
        }
    }
}