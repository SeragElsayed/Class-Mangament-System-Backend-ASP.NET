using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Web.Http.Tracing;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;

namespace onlinelearningbackend.Controllers
{
    public class TracksController : Controller
    {
        ITrackManager TrackManager;
        public TracksController(ITrackManager _db)
        {
            this.TrackManager = _db;
        }



        [HttpGet]
        [Route("api/Track")]
        public IActionResult GetAllTracks()
        {
            var Trackes = TrackManager.GetAllTracks();

            if (Trackes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Trackes);
            }

        }
        [HttpGet]
        [Route("api/Track/{BranchId}")]
        public IActionResult GetTrackById(int BranchId)
        {
            if (BranchId < 1)
                return BadRequest();

            var Trackes = TrackManager.GetAllTracksByBranchId(BranchId);

            if (Trackes == null)
                return NotFound();

            return Ok(Trackes);

        }
        [HttpPost]
        [Route("api/Track/Add")]
        public IActionResult PostNewTrack([FromBody] Track NewTrack)
        {
            var TrackInDb = TrackManager.AddTrack(NewTrack);
            return Ok(TrackInDb);

        }
        [HttpPut]
        [Route("api/Track/Edit/{TrackId}")]
        public IActionResult PutTrack([FromBody] Track EditedTrack)
        {
            var TrackInDb = TrackManager.EditTrack(EditedTrack);

            return Ok(TrackInDb);

        }
        [HttpDelete]
        [Route("api/Track/Delete/{TrackId}")]
        public IActionResult DeleteTrack(int TrackId)
        {
            TrackManager.DeleteTrackById(TrackId);

            return Ok();

        }
    }
}