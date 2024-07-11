using BillLibrary.Models;
using BillLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        IUserDetails repo;
        public UserDetailsController(IUserDetails user)
        {
            repo=user;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(UserDetails user)
        {
            try
            {
                await repo.AddNewUser(user);
                return Created($"api/UserDetails/{user.Id}", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
