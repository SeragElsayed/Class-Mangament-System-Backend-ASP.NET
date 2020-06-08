using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.Manager
{
    public class BranchManager:IBranchManager
    {
        ApplicationDbContext db;
        public BranchManager(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public List<Branch> GetAllBranchs()
        {
            var branches = db.Branches.FromSqlRaw<Branch>("EXEC dbo.usp_Branches").ToList<Branch>();
            return branches;
        }
    }
}
