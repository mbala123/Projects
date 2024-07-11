using FileLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Repositories
{
    public interface IFileManager
    {
        Task<FileManager> GetOneFile(int fileId);
        Task<FileManager> GetByFileName(int userId,string fileName);
        Task<List<FileManager>> GetFilesByUserId(int userId);
        Task<List<FileManager>> GetFilesByCategory(int userId, int categoryId);
        Task InsertFile(FileManager file);
        Task DeleteFile(int fileId);
    }
}
