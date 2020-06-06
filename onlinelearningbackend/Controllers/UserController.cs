using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using onlinelearningbackend.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Net.Http.Headers;
using onlinelearningbackend.Helpers;

namespace onlinelearningbackend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<MyUserModel> _signInManager;
       
        private readonly UserManager<MyUserModel> _userManager;
        private readonly RoleManager<MyRoleModel> _roleManager;

        private readonly ApplicationSetting _AppSetting;

        public UserController(
            UserManager<MyUserModel> userManager,
            SignInManager<MyUserModel> signInManager,
            RoleManager<MyRoleModel> roleManager,
            IOptions<ApplicationSetting> AppSetting)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _AppSetting = AppSetting.Value;
        }


        [HttpPost]
        [Route("api/user/Register")]

        // Post api/user/register
        public async Task<object> PostRegister([FromForm] UserRegisterModel NewUser)
        {
            var file = Request.Form.Files[0];
            bool IsInfoValid = NewUser.UserName != null && NewUser.Password != null;
            bool IsImageUploaded = file.Length > 0;

            if (  IsInfoValid== false)
                {
                    return BadRequest(new { message = "invalid registration info" });
                }
            if (  IsImageUploaded==  false)
                {
                    var user = await _userManager.CreateAsync(NewUser, NewUser.Password);
                    return Ok(user);
                }

            var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var IsImgExtAllowed = FSHelpers.IsImageExtensionAllowed(uploadedfilename);
            if (IsImgExtAllowed == false)
            {
                return BadRequest(new { message = "Image extensions allowed are jPG and PNG only " });

            }
            var dbImagePath = FSHelpers.SaveProfileImage(NewUser, uploadedfilename, file);
            
            

            NewUser.PrifleImageUrl = dbImagePath;

            var result = await _userManager.CreateAsync(NewUser, NewUser.Password);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/user/Login")]
        //Post api/user/Login
        public async Task<IActionResult> PostLogin(UserLoginModel model)
        {
            var key = Encoding.UTF8.GetBytes(_AppSetting.JWT_Secret);
            var User = await _userManager.FindByNameAsync(model.UserName);
            if(User !=null && await _userManager.CheckPasswordAsync(User, model.Password))
            {
                var Token = TokenHelpers.CreateToken(User, key);
                
                return Ok(new { Token });
            }
            else
            {
                return BadRequest(new { message = "Login Info not valid" });
            }
        }

        [HttpGet]
        [Route("api/user/Profile")]
        [Authorize]
        // Get api/user/profile 
        public async Task<Object> GetProfile()
        {
            string UserId = User.Claims.First(c => c.Type == "UserId").Value;
            var UserData = await _userManager.FindByIdAsync(UserId);
            return new
            {
                UserData.UserName,
                UserData.PrifleImageUrl
                
            };
        }
        [HttpPut]
        [Route("api/user/Profile")]
        [Authorize]
        // Get api/user/profile 
        public async Task<Object> PatchProfile([FromForm]UserPatchProfileModel EditedUser)
        {
            var file = Request.Form.Files[0];
            bool IsInfoValid = EditedUser.UserName != null ;
            bool IsImageUploaded = file.Length > 0; 
            string UserId = User.Claims.First(c => c.Type == "UserId").Value;
            var UserInDB = await _userManager.FindByIdAsync(UserId);
            string oldImagePath = UserInDB.PrifleImageUrl;
            UserInDB.UserName = EditedUser.UserName;

            if (!IsInfoValid)
            {
                return BadRequest(new { message = "invalid Edited info" });
            }
            if (!IsImageUploaded)
            {
                var user = await _userManager.UpdateAsync(UserInDB);
                return Ok(user);
            }

            var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var dbImagePath = FSHelpers.SaveProfileImage(UserInDB, uploadedfilename, file);
            FSHelpers.DeleteOldImage(oldImagePath);

            if (dbImagePath == null)
            {
                return BadRequest(new { message = dbImagePath });
            }

            UserInDB.PrifleImageUrl = dbImagePath;

            var result = await _userManager.UpdateAsync(UserInDB);

            //return Ok(result);
            return new
            {
                UserInDB.UserName,
                UserInDB.PrifleImageUrl

            };
        }
    }
}