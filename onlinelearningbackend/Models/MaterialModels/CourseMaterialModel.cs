
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class CourseMaterialModel 
    {
        public int Id { get; set; }
        [Required]
        public string PathOnServer { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [Required]
        public Course Course { get; set; }
    }
}
