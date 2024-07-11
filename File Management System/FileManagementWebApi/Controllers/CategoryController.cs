using FileLibrary.Models;
using FileLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory repository;

        public CategoryController(ICategory cat)
        {
            repository = cat;
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult> GetCategoryByUserId(int userId)
        {
            try
            {
                List<Category> categories = await repository.GetCategoryByUserId(userId);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertNewCategory(Category category)
        {
            try
            {
                await repository.InsertCategory(category);
                  return Created($"api/Category/{category.UserId}", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
