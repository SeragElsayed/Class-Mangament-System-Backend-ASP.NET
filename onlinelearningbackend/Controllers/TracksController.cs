using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Web.Http.Tracing;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Repo.IManager;

namespace onlinelearningbackend.Controllers
{
    public class TracksController : Controller
    {
        ITrackManager db;
        public TracksController(ITrackManager _db)
        {
            this.db = _db;
        }
        [HttpGet]
        
        [Route("api/explore/Branches/Tracks/{id}")]
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

    }
}