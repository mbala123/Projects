using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using TaskLibrary.Models;
using TaskLibrary.Repos;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        //Dependency injection
        IUserRegistration repo;
        public UserRegistrationController(IUserRegistration register)
        {
            repo=register;
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="userName"></param>
        /// <returns Details of particular user></returns>
        [HttpGet("Byusername/{userName}")]
        public async Task<ActionResult> GetOne(string userName)
        {
            try
            {
                UserRegistration r = await repo.GetOne(userName);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insert new user
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Insert(UserRegistration register)
        {
            try
            {
                await repo.Register(register);
                return Created($"api/UserRegistration/{register.UserName}", register);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all user details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllDetails()
        {
            try
            {
                List<UserRegistration> reg = await repo.GetAll();
                return Ok(reg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
