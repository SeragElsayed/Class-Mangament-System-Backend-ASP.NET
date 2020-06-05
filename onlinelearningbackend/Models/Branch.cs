using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchEmail { get; set; }
        public string BranchTelephone { get; set; }
        public virtual ICollection<MyUserModel> MyUserModels { get; set; } = new HashSet<MyUserModel>();
    }
}
