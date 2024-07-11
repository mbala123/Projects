using FileLibrary.Models;
using FileLibrary.Repositories;
using FileManagementWebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IFileManager repository;

        public FileManagerController(IFileManager file)
        {
            repository = file;
        }

        [HttpGet("GetByCategory/{userId}/{categoryId}")]
        public async Task<ActionResult> GetByCategory(int userId, int categoryId)
        {
            try
            {
                List<FileManager> files = await repository.GetFilesByCategory(userId, categoryId);
                return Ok(files);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByFileName/{userId}/{fileName}")]
        public async Task<ActionResult> GetByFileName(int userId, string fileName)
        {
            try
            {
               // string fileName = fileData.FileName;
                FileManager file = await repository.GetByFileName(userId, fileName);
                return Ok(file);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
            try
            {
                List<FileManager> files = await repository.GetFilesByUserId(userId);
                return Ok(files);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ById/{fileId}")]
        public async Task<ActionResult> GetByFileId(int fileId)
        {
            try
            {
                FileManager file = await repository.GetOneFile(fileId);
                return Ok(file);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertFile([FromForm] IFormFile fileData,[FromForm] string fileName, [FromForm] int categoryId, [FromForm] string securityType, [FromForm] bool isDeleted, [FromForm] int createdBy, [FromForm] int userId, [FromForm] string password)
        {
            try
            {
                if (fileData == null || fileData.Length == 0)
                {
                    return BadRequest("File data is required");
                }

                string fileUrl = $"{fileData.FileName}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(fileData.FileName)}";
                string filePath = Common.GetFilePath(fileUrl);


                // Save the file to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileData.CopyToAsync(stream);
                }

                var fileManager = new FileManager
                {
                   // FileName = fileData.FileName,
                    FileName=fileName,
                    CategoryId = categoryId,
                    SecurityType = securityType,
                    isDeleted = isDeleted,
                    CreatedBy = createdBy,
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow,
                    Password=password,
                    FileData = fileUrl
                };

                await repository.InsertFile(fileManager);
                return Created($"api/FileManager/{fileManager.FileId}", fileManager);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{fileId}")]
        public async Task<ActionResult> DeleteFile(int fileId)
        {
            try
            {
                await repository.DeleteFile(fileId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Download/{fileId}")]
        public async Task<IActionResult> DownloadFile(int fileId)
        {
            try
            {
                var (fileData, contentType, actualFileName) = await DownloadFileAsync(fileId);
                return File(fileData, contentType, actualFileName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<(byte[] fileData, string contentType,string fileName)> DownloadFileAsync(int fileId)
        {
            try
            {
                var file = await repository.GetOneFile(fileId);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(file.FileData, out var contentType))
                {
                    contentType = "application/octet-stream";
                }
                string filePath=Common.GetFilePath(file.FileData);
           //     string FileName = Path.GetFileName(filePath);
                byte[] fileData = await System.IO.File.ReadAllBytesAsync(filePath);
                return (fileData, contentType, Path.GetFileName(file.FileData));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
