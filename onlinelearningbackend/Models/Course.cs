
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int IntervalInDays { get; set; }
        public DateTime StartingDate { get; set; }
        public string EnrollmentKey { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual Track Track { get; set; }
        public virtual ICollection<CourseMyUserModel> CourseMyUserModels { get; set; } = new HashSet<CourseMyUserModel>();
        public virtual ICollection<TaskClass> Tasks { get; set; } = new HashSet<TaskClass>();
        public virtual ICollection<TaskSolution> TaskSolutions { get; set; } = new HashSet<TaskSolution>();
        public virtual ICollection<TextMaterial> TextMaterials { get; set; } = new HashSet<TextMaterial>();
        public virtual ICollection<VideoMaterial> VideoMaterials { get; set; } = new HashSet<VideoMaterial>();
        public virtual ICollection<LinkMaterial> LinkMaterials { get; set; } = new HashSet<LinkMaterial>();
    }
}
