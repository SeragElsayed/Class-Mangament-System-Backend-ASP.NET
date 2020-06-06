using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class UserPatchProfileModel:MyUserModel
    {
        public string UserName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string PrifleImageUrl { get; set; }
    }
}
