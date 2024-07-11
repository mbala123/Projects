using FileLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Repositories
{
    public interface ICategory
    {
        Task<List<Category>> GetCategoryByUserId(int userId);
        Task InsertCategory(Category category);
    }
}
