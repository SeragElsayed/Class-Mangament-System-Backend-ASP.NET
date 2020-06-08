using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
    public interface ITrackManager
    {
        List<Track> GetAllTracksByBId(int id);
    }
}
