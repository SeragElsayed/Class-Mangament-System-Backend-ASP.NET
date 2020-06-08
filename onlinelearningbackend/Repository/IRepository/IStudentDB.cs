using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repository.IRepository
{
    public interface IStudentDB
    {
        List<MyUserModel> GetStudentByCrsId(int id);
        List<MyUserModel> GetStudentByTrackId(int id);

        MyUserModel GetStudentByStdId(int id);

       

        List<TaskSolution> GetStdTaskBYCrsIdStdId(int crsId, int stdId);
    }
}
