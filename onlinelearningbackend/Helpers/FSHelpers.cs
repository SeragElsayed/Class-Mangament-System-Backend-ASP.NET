using Microsoft.AspNetCore.Http;
using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Helpers
{
    public static class FSHelpers
    {
        private static string AllowedExtensions = "jpgpng";
        public static bool IsImageExtensionAllowed(string uploadedfilename)
        {
            var ReverseFileName =string.Concat( uploadedfilename.Reverse());
            var imageExtension = string.Concat(uploadedfilename.TakeWhile((c)=>c=='.')).ToLower();
            return AllowedExtensions.Contains(imageExtension);
        }
        public static void DeleteOldImage(string OldFilePath)
        {
             var ArrayOldFilePath = OldFilePath.Split('/');
            var filename = ArrayOldFilePath[ArrayOldFilePath.Length - 1];
            var folderName = Path.Combine("Resources", "ProfilePictures");
            var pathToDelete = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToDelete, filename);
            File.Delete(fullPath);
        }
        public static string SaveProfileImage(MyUserModel User,string uploadedfilename,IFormFile file)
        {
          
            var folderName = Path.Combine("Resources", "ProfilePictures");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
             //uploadedfilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileExtension = uploadedfilename.Substring(uploadedfilename.Length - 3).ToLower();
            //bool IsImgExtAllowed = IsImageExtensionAllowed(fileExtension);

            //if (!IsImgExtAllowed)
            //{
            //    return "image extension must be jpg or png";
            //}

                var fileName = $"{User.UserName}.{fileExtension}";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = $"{folderName.Replace('\\', '/')}/{fileName}";
               // User.PrifleImageUrl = dbPath;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            return dbPath;
           
        }
        //material text file upload
        public static string SaveMaterialText(string uploadedfilename, IFormFile file)
        {
            var folderName = Path.Combine("Resources", "MaterialText");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = uploadedfilename;
        var fullPath = Path.Combine(pathToSave, fileName);
            if (!(System.IO.File.Exists(fullPath)))
            {
                var dbPath = $"{folderName.Replace('\\', '/')}/{fileName}";

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return dbPath;
            }
            return "exists";

        }
    }
}
