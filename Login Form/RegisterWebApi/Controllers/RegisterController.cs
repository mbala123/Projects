using LoginFormLibrary.Models;
using LoginFormLibrary.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegisterWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IRegisterRepo repo;
        public RegisterController(IRegisterRepo register)
        {
            repo = register;
        }

        [HttpGet("Byusername/{username}")]
        public async Task<ActionResult> GetOne(string username)
        {
            try
            {
                Register r = await repo.GetOne(username);
                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDetails()
        {
            try
            {
                List<Register> reg = await repo.GetAll();
                return Ok(reg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Register r)
        {
            try
            {
                await repo.Insert(r);
                return Created($"api/Register/{r.username}", r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{username}")]
        public async Task<ActionResult> Update(string username,Register r)
        {
            try
            {
                await repo.Update(username,r);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string username)
        {
            try
            {
                await repo.Delete(username);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
