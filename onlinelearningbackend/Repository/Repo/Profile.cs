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
    public class Profile:IProfile
    {
        ApplicationDbContext db;
        public Profile(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public List<Course> GetStdCrsByStdId(int id)
        {
            var courses = db.Courses.FromSqlRaw<Course>($"dbo.usp_Courses_StdId {id}").ToList();
            return courses;
        }
        //public void UpdateProfile(string id, string name)
        //{
        //    db.Users.FromSqlRaw<MyUserModel>($"dbo.usp_AspNetRoles_Update");
        //}
    }
}
