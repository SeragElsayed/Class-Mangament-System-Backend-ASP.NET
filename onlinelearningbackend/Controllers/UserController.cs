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
//using System.Web.Http;
//using System.Web.Http;

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

            if (IsInfoValid)
            {
                if (IsImageUploaded)
                {
                    var folderName = Path.Combine("Resources", "ProfilePictures");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileExtension = uploadedfilename.Substring(uploadedfilename.Length - 3).ToLower();
                    bool IsImgExtAllowed = AllowedImageExtensions.AllowedExtensions.Contains(fileExtension);
                    if (IsImgExtAllowed)
                    {
                        var fileName = $"{NewUser.UserName}.{fileExtension}";
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = $"{folderName.Replace('\\', '/')}/{fileName}";
                        NewUser.PrifleImageUrl = dbPath;
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        var result = await _userManager.CreateAsync(NewUser, NewUser.Password);
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(new { message = "image extension must be jpg or png" });

                    }

                }
                else  
                {
                    var result = await _userManager.CreateAsync(NewUser, NewUser.Password);
                    return Ok(result);
                }
            }
            else
            {
                return BadRequest(new { message = "invalid registration info" });

            }
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
                UserData.Age,
                UserData.PrifleImageUrl
                
            };
        }
    }
}