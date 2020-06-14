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
        ITrackManager trackClass;
        public TracksController(ITrackManager _trackClass)
        {
            this.trackClass = _trackClass;
        }
        [HttpGet]
        
        [Route("api/explore/Branches/Tracks/{branchId}")]
        public IActionResult GetAllTracksByBranchId(int branchId)
        {
            var tracks = trackClass.GetAllTracksByBranchId(branchId);

            if (tracks == null)
            {
                return NotFound();
            }
            
                return Ok(tracks);
            

        }

    }
}