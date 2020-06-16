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
    [Route("api/[controller]")]
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
            List<Object> Collaborators=new List<Object>();
            foreach (var item in userProjectList)
            {
                var user = await _userManager.FindByIdAsync(item.myUserModel.Id);
                if (user == null)
                    continue;
               var UserProject= UserProjectManager.GetCollaboratorIdByProjectId(ProjectId);
                Collaborators.Add(new { User,UserProject});
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
        public async Task<IActionResult> PostAddCollaboratorByEmail(int ProjectId,string Email)
        {

            string UserId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = UserProjectManager.GetUserProjectIdByStudentId(UserId);

            if (user.IsOwner == false)
                return Unauthorized();
            var CollabortorToAdd = await _userManager.FindByEmailAsync(Email);
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

            string UserId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = UserProjectManager.GetUserProjectIdByStudentId(UserId);

            if (user.IsOwner == false)
                return Unauthorized();

            UserProjectManager.DeleteCollaboratorByUserId(StudentId);


            return Ok();
        }



    }
}