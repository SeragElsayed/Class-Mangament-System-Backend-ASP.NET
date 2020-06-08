using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repository.IRepository
{
    public interface IProfile
    {
        List<Course> GetStdCrsByStdId(int id);

        //void UpdateProfile(string id, string name);

    }
}
