using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class UserProjectModel
    {
        public int UserProjectModelId { get; set; }
        public bool IsOwner { get; set; }
        
        public MyUserModel myUserModel { get; set; }
        public ProjectModel projectModel { get; set; }
    }
}
