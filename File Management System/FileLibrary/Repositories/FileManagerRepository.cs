using FileLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Repositories
{
    public class FileManagerRepository : IFileManager
    {
        FileDbContext dbContext = new FileDbContext();
        public async Task DeleteFile(int fileId)
        {
            FileManager file = await GetOneFile(fileId);
            file.isDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task<FileManager> GetByFileName(int userId,string fileName)
        {
            try
            {
                FileManager file=await(from f in dbContext.FileManagers where f.UserId==userId && f.FileName == fileName && f.isDeleted==false select f).FirstAsync();
                return file;
            }
            catch (Exception ex)
            {
                throw new Exception("No file is available in given file name");
            }
        }

        public async Task<List<FileManager>> GetFilesByCategory(int userId, int categoryId)
        {
            try
            {
                List<FileManager> files = await (from file in dbContext.FileManagers where file.UserId == userId && file.CategoryId == categoryId && file.isDeleted == false select file).Include(file => file.Category).ToListAsync();
                return files;
            }
            catch
            {
                throw new Exception("No files are available for given category");
            }
        }

        public async Task<List<FileManager>> GetFilesByUserId(int userId)
        {
            try
            {
                List<FileManager> files = await (from file in dbContext.FileManagers where file.UserId == userId && file.isDeleted == false select file).Include(file=>file.Category).ToListAsync();
                return files;
            }
            catch
            {
                throw new Exception("No files are available for this user");
            }
        }

        public async Task<FileManager> GetOneFile(int fileId)
        {
            try
            {
                FileManager file = await (from f in dbContext.FileManagers where f.FileId==fileId && f.isDeleted == false select f).FirstAsync();
                return file;
            }
            catch
            {
                throw new Exception("No such file is available");
            }

        }

        public async Task InsertFile(FileManager file)
        {
            await dbContext.FileManagers.AddAsync(file);
            await dbContext.SaveChangesAsync();
        }
    }



}
