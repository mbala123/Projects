using FileLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLibrary.Repositories
{
    public class CategoryRepository : ICategory
    {
        FileDbContext dbContext = new FileDbContext();
        public async Task<List<Category>> GetCategoryByUserId(int userId)
        {
            try
            {
                List<Category> categories = await (from category in dbContext.Categories where category.UserId == userId select category).ToListAsync();
                return categories;
            }
            catch(Exception ex)
            {
                throw new Exception("No category is available for given user");
            }

        }

        public async Task InsertCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }
    }
}
