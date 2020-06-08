using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repository.IRepository
{
    public interface IExploreCrs
    {
        List<Branch> GetAllBranchs();
        List<Track> GetAllTracksByBId(int id);
        List<Course> GetAllCrsByTId(int id);
    }
}
