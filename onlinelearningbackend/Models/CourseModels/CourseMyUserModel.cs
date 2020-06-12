using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class CourseMyUserModel
    {
        public int CourseMyUserModelId { get; set; }
        public Course Course { get; set; }

        public MyUserModel MyUserModel { get; set; }
    }
}
