using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;

namespace onlinelearningbackend.Controllers
{
    [ApiController]
    public class UserProjectRolesController : ControllerBase
    {
        IUserProjectManager UserProjectManager;

        private readonly UserManager<MyUserModel> _userManager;
        public UserProjectRolesController(
            IUserProjectManager UPM,
            UserManager<MyUserModel> userManager)
        {
            UserProjectManager = UPM;
            _userManager = userManager;

        }

        //IEnumerable<UserProjectModel> GetCollaboratorIdByProjectId(int ProjectId);

        [HttpGet]
        [Route("api/PM/{ProjectId}")]
        public async Task<IActionResult> GetCollaboratorIdByProjectId(int ProjectId)
        {
            var userProjectList = UserProjectManager.GetCollaboratorIdByProjectId( ProjectId);

            if (userProjectList.Count() == 0)
                return Ok();

            string UserId = User?.Claims?.First(c => c.Type == "UserId")?.Value;
            List<Object> Collaborators=new List<Object>();

            foreach (var item in userProjectList)
            {
                var user = await _userManager.FindByIdAsync(item?.MyUserModelId);
                if (user == null || user.Id== UserId)
                    continue;
               var UserProject= UserProjectManager.GetUserProjectIdByStudentId(item?.MyUserModelId);
                Collaborators.Add(new { user,UserProject});
            }

            if (Collaborators == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Collaborators);
            }

        }


        //public void AddCollaboratorByUserId(string UserId, int ProjectId);

        [HttpPost]
        [Route("api/PM/{ProjectId}/{Email}")]
        [System.Web.Http.Authorize]
        public async Task<IActionResult> PostAddCollaboratorByEmail([FromRoute]int ProjectId,[FromRoute]string Email)
        {

            string ProjectOwnerId = User.Claims.First(c => c.Type == "UserId").Value;
            var ProjectOwner = UserProjectManager.GetUserProjectIdByStudentId(ProjectOwnerId);
            

            if (ProjectOwner == null)
                return Unauthorized();

            if (ProjectOwner.IsOwner == false)
                return Unauthorized();

            var CollabortorToAdd = await _userManager.FindByEmailAsync(Email);

            var Collaborators = UserProjectManager.GetCollaboratorIdByProjectId(ProjectId);

            if (Collaborators.FirstOrDefault(c => c.MyUserModelId == CollabortorToAdd.Id) != null)
                return Ok();

            UserProjectManager.AddCollaboratorByUserId(CollabortorToAdd.Id,ProjectId);

            return Ok();
        }


        //public void MakeCollaboratorOwnerByUserId(string UserId);

        [HttpPost]
        [Route("api/PM/MakeOwner/{ColabId}")]
        public IActionResult PostMakeCollaboratorOwnerByEmail( string ColabId)
        {

            string UserId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = UserProjectManager.GetUserProjectIdByStudentId(UserId);

            if (user.IsOwner == false)
                return Unauthorized();
            //var CollabortorToAdd = await _userManager.FindByIdAsync(ColabId);
            UserProjectManager.MakeCollaboratorOwnerByUserId(ColabId);


            return Ok();
        }

        //public void DeleteCollaboratorByUserId(string UserId);


        [HttpDelete]
        [Route("api/PM/Remove/{StudentId}")]
        public  IActionResult DeleteCollaboratorByUserId(string StudentId)
        {

            string OwnerId = User.Claims.First(c => c.Type == "UserId").Value;
            var owner = UserProjectManager.GetUserProjectIdByStudentId(OwnerId);

            if (owner?.IsOwner == false)
                return Unauthorized();

            var userToDelete = UserProjectManager.GetUserProjectIdByStudentId(StudentId);

            if (userToDelete?.IsOwner == true)
                return Unauthorized();

            UserProjectManager.DeleteCollaboratorByUserId(StudentId);

            return Ok();
        }



    }
}