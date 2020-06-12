using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
    public interface ITrackManager
    {
        List<Track> GetAllTracks();
        List<Track> GetAllTracksByBranchId(int BranchId);
        Track AddTrack(Track NewTrack);
        Track EditTrack(Track EditedTrack);
        void DeleteTrackById(int TrackId);

    }
}
