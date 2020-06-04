using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class MyUserModel:IdentityUser
    {
        public MyUserModel():base()
        {
            Age = 0;
        }
        public MyUserModel(string UserName):base(UserName)
        {

        }
        
        public string PrifleImageUrl { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
    }
}
