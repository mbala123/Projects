using BillLibrary.Models;
using BillLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillItemController : ControllerBase
    {
        IBillItems repo;
        public BillItemController(IBillItems bill)
        {
            repo = bill;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(BillItems bill)
        {
            try
            {
                await repo.AddNewbill(bill);
                return Created($"api/BillItem/{bill.BillId}",bill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
