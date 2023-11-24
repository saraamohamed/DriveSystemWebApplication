using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DriveSystemWebApplication.Models;
using DriveSystemWebApplication.Repository.FileRepository;
using System.Security.Claims;
using System;
using System.IO;
using System.Collections.Generic;

namespace DriveSystemWebApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesApiController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FilesApiController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet("GetFilesByuserId")]
        public IActionResult GetFilesByuserId(int userId)
        {
           
            List<Models.File> allFilesModel = _fileRepository.GetAllByUserId(userId);

            return Ok(allFilesModel);
        }

        [HttpPost("UploadFile")]
        public IActionResult UploadFile(IFormFile file)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Int32.Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objFile = new Models.File()
                    {
                        DocumentId = 0,
                        Name = newFileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now,
                        UserId = userId
                    };

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        objFile.DataFiles = target.ToArray();
                    }

                    _fileRepository.Insert(objFile);
                    return Ok("File uploaded successfully.");
                }
            }

            return BadRequest("Invalid request or file not provided.");
        }

        [HttpGet(("DownloadFile/{fileId}"))]
        public IActionResult DownloadFile(int fileId)
        {
            var file = _fileRepository.GetById(fileId);
            if (file == null)
            {
                return NotFound("File not found.");
            }

            var stream = new MemoryStream(file.DataFiles);
            var contentType = GetContentType(file.FileType);

            return File(stream, contentType, file.Name);
        }

        [HttpPost("{fileId}")]
        public IActionResult DeleteFile(int fileId)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Int32.Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            Models.File file = _fileRepository.GetById(fileId);
            if (file != null)
            {
                _fileRepository.Delete(fileId);
                return Ok("File deleted successfully.");
            }

            return NotFound("File not found.");
        }

        private string GetContentType(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".txt":
                    return "text/plain";
                case ".pdf":
                    return "application/pdf";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
