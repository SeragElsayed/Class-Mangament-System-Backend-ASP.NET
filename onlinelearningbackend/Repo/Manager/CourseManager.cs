using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.DAL
{
    public class CourseManager : ICourseManager
    {
        ApplicationDbContext DB;
        public CourseManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }
        public Course CoursesByCourseId(int CourseId)
        {
            var Courses = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Select {0}", CourseId).ToList<Course>().FirstOrDefault();
            return Courses;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var Courses = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_SelectAll").ToList<Course>();
            return Courses;
        }
        public IEnumerable<Course> CoursesByStudentId(string StudentId)
        {
            var Courses = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Select_by_Student_Id {0}", StudentId).ToList<Course>();
            return Courses;
        }
        public IEnumerable<Course> CoursesByInstructorId(string InstructorId)
        {
            var Courses = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Select_by_Instructor_Id {0}", InstructorId).ToList<Course>();
            return Courses;
        }
        public IEnumerable<Course> CoursesByTrackId(int TrackId)
        {
            var Courses = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Select_by_Track_Id {0}", TrackId).ToList<Course>();
            return Courses;
        }
        //public Course AddCourse(Course NewCourse, string InstructorId)
        public Course AddCourse(Course NewCourse, string InstructorId, int TrackId)


        {
            var course = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Insert {0},{1},{2},{3},{4},{5},{6}"
                                                , NewCourse.CourseName,
                                                NewCourse.Description,
                                                NewCourse.IntervalInDays,
                                                NewCourse.StartingDate,
                                                NewCourse.EnrollmentKey,
                                                //NewCourse.Topic,//.TopicId,
                                                TrackId,
                                                InstructorId
                                                ).ToList<Course>().FirstOrDefault();
            return course;
        }
        public Course EditCourse(Course EditedCourse)
        {
            var Course = DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Insert {0},{1},{2},{3},{4},{5},{6}",
                                                EditedCourse.CourseId,
                                                EditedCourse.CourseName,
                                                EditedCourse.Description,
                                                EditedCourse.IntervalInDays,
                                                EditedCourse.StartingDate,
                                                EditedCourse.EnrollmentKey,
                                                EditedCourse.Topic.TopicId,
                                                EditedCourse.Track.TrackId
                                                )
                                            .ToList<Course>().FirstOrDefault();
            return Course;
        }

        public void DeleteCoursesByCourseId(int CourseId)
        {
            DB.Courses.FromSqlRaw("EXEC dbo.usp_Courses_Delete {0}", CourseId).ToList<Course>();

        }
        public void EnrollStudentInCourse(int CourseId, string StudentId)
        {
            DB.Courses.FromSqlRaw("EXEC dbo.usp_CourseMyUserModel_Insert {0}", CourseId, StudentId).ToList<Course>();

        }

    }
}
