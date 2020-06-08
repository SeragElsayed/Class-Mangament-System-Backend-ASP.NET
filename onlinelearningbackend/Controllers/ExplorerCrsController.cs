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
    public class ExplorerCrsController : Controller
    {
        IExploreCrs db;
        public ExplorerCrsController(IExploreCrs _db)
        {
            this.db = _db;
        }

        [HttpGet]
        [Authorize]
        [Route("api/explore/Branches")]
        public async Task<IActionResult> GetAllBranchs()
        {
            var branches =  db.GetAllBranchs();

            if(branches==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(branches);
            }

        }
        [HttpGet]
        [Authorize]
        [Route("api/explore/Branches/Tracks")]
        public async Task<IActionResult> GetAllTracks(int id)
        {
            var tracks = db.GetAllTracksByBId(id);

            if (tracks == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tracks);
            }

        }
        [HttpGet]
        [Authorize]
        [Route("api/explore/Branches/coursess")]
        public async Task<IActionResult> GetAllCrs(int id)
        {
            var courses = db.GetAllCrsByTId(id);

            if (courses == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(courses);
            }

        }

    }
}