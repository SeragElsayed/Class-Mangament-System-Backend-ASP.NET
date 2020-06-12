using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.Manager
{
    public class TrackManager:ITrackManager
    {
        ApplicationDbContext db;
        public TrackManager(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public List<Track> GetAllTracks()
        {
            var tracks = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_Select ").ToList<Track>();
            return tracks;
        }
        public List<Track> GetAllTracksByBranchId(int branchId)
        {
            var tracks = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_BrId {branchId}").ToList<Track>();
            return tracks;
        }
        public Track EditTrack(Track EditedTrack)
        {
            var track = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_Update '{EditedTrack.TrackName}'").FirstOrDefault();
            return track;
        }
        public Track AddTrack(Track NewTrack)
        {
            var track = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_Insert '{NewTrack.TrackName}'").FirstOrDefault();
            return track;
        }
        public void DeleteTrackById(int TrackId)
        {
            db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_Delete {TrackId}");
        }

        public Track GetAllTracksByTrackId(int TrackId)
        {
            var track = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_Track_Id {TrackId}").ToList<Track>().FirstOrDefault();
            return track;
        }
    }
}
