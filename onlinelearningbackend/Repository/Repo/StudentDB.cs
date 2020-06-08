using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repository.Repo
{
    public class StudentDB:IStudentDB
    {
        ApplicationDbContext db;
        public StudentDB(ApplicationDbContext _db )
        {
            this.db = _db;
        }
        

        public List<MyUserModel> GetStudentByCrsId(int id)
        {
            var users = db.Users.FromSqlRaw<MyUserModel>($"dbo.usp_StudentS_CrsId {id}").ToList();
      
            return users;
        }
        public List<MyUserModel> GetStudentByTrackId(int id)
        {
            var users = db.Users.FromSqlRaw<MyUserModel>($"dbo.usp_StudentS_TrackId {id}").ToList();
          
            return users;
        }
        
 public MyUserModel GetStudentByStdId(int id)
        {
            var user = db.Users.FromSqlRaw<MyUserModel>($"dbo.usp_Students_StdId {id}");
            MyUserModel u = user as MyUserModel;
            return u;
        }
      
        public List<TaskSolution> GetStdTaskBYCrsIdStdId(int crsId,int stdId)
        {
            var tasks = db.TaskSolutions.FromSqlRaw<TaskSolution>($"dbo.usp_StudentS_Tasks_CrsId{crsId}{stdId}").ToList();
            return tasks;
        }
    }
}
