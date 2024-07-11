using FileLibrary.Models;
using FileLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccount repository;
        public AccountController(IAccount account)
        {
             repository = account;
        }

        [HttpGet("ByMail/{email}")]
        public async Task<ActionResult> GetOneAccount(string email)
        {
            try
            {
                Account account = await repository.GetOneAccount(email);
                return Ok(account);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Login/{email}/{password}")]
        public async Task<ActionResult> Login(string email, string password)
        {
            try
            {
                var response = await repository.IsLogin(email, password);
               
                 return Ok(new { isSuccess = response.IsSuccess, message = response.Message, userId=response.UserId,name=response.UserName });
               
            }
            catch (Exception ex)
            {
                return Ok(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(Account account)
        {
            try
            {
               var response=await repository.SignUp(account);
                return Ok(new { isSuccess = response.IsSuccess, message = response.Message, });
            }
            catch(Exception ex)
            {
                return Ok(new {isSuccess=false, message = ex.Message});
            }
        }

    }
}
