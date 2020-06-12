using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
   public interface IUserProjectManager
    {
        public UserProjectModel GetUserProjectIdByStudentId(string studentId);

       public IEnumerable<UserProjectModel> GetCollaboratorIdByProjectId(int ProjectId);
        public void AddCollaboratorByUserId(string UserId, int ProjectId);
        public void MakeCollaboratorOwnerByUserId(string UserId);
        public void DeleteCollaboratorByUserId(string UserId);



    }
}
