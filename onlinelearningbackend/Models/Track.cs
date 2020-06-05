﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public Branch Branch { get; set; }
        public virtual ICollection<MyUserModel> MyUserModels { get; set; } = new HashSet<MyUserModel>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
