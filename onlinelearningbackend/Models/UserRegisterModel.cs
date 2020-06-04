using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class UserRegisterModel:MyUserModel
    {
        public string Password { get; set; }
    }
}
