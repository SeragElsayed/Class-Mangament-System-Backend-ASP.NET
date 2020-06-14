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
        public List<Track> GetAllTracksByBranchId(int branchId)
        {
            var tracks = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_BrId {branchId}").ToList<Track>();
            return tracks;
        }
    }
}
