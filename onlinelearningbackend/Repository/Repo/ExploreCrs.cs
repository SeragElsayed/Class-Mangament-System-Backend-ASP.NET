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
    public class ExploreCrs : IExploreCrs
    {
        ApplicationDbContext db;
        public ExploreCrs(ApplicationDbContext _db)
        {
            this.db = _db;   
        }
        //var students = context.Students
        //              .FromSql($"GetStudents {name}")
        //              .ToList();
        public List<Branch> GetAllBranchs()
        {
            var branches = db.Branches.FromSqlRaw<Branch>("EXEC dbo.usp_Branches").ToList<Branch>();
            return branches;
        }

        public List<Course> GetAllCrsByTId(int id)
        {
            
               var course = db.Courses.FromSqlRaw<Course>($"EXEC dbo.usp_Courses_TrId {id}").ToList<Course>();
            return course;
        }

        public List<Track> GetAllTracksByBId(int id)
        {
            var tracks = db.Tracks.FromSqlRaw<Track>($"EXEC dbo.usp_Tracks_BrId {id}").ToList<Track>();
            return tracks;
        }
    }
}
