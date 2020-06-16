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
    public class UserProjectManager:IUserProjectManager
    {
        ApplicationDbContext db;
        public UserProjectManager(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public UserProjectModel GetUserProjectIdByStudentId(string studentId)
        {
            var UserProject = db.UserProjectModels.FromSqlRaw<UserProjectModel>($"EXEC dbo.usp_UserProjectModel_Select_By_Student_ID '{studentId}'").ToList<UserProjectModel>().FirstOrDefault();
            return UserProject;
        }
        public IEnumerable<UserProjectModel> GetCollaboratorIdByProjectId(int ProjectId)
        {
            var Collaborators = db.UserProjectModels.FromSqlRaw<UserProjectModel>($"EXEC dbo.usp_UserProjectModel_Select_By_Project_ID {ProjectId}").ToList<UserProjectModel>();
            return Collaborators;
        }
        public UserProjectModel AddCollaboratorByUserId(string UserId,int ProjectId)
        {
           var addedcolab= db.UserProjectModels.FromSqlRaw<UserProjectModel>($"EXEC dbo.usp_UserProjectModel_Add_Collaborator '{UserId}' , {ProjectId}").ToList().FirstOrDefault();
            return addedcolab;
        }
        public void MakeCollaboratorOwnerByUserId(string UserId)
        {
           db.Database.ExecuteSqlRaw($"EXEC dbo.usp_UserProjectModel_Make_Owner '{UserId}'");
           
        }

        public void DeleteCollaboratorByUserId(string UserId)
        {
            var x= db.Database.ExecuteSqlRaw($"EXEC dbo.usp_UserProjectModel_Delete '{UserId}'");
         
        }
    }
}
