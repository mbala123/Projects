using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLibrary.Models;
using TaskLibrary.Repos;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        //Dependency injection
        IHistory repo;
        public HistoryController(IHistory history)
        {
            repo= history;
        }

        /// <summary>
        /// List of all history
        /// </summary>
        /// <returns All history ></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllHistories()
        {
            try
            {
                List<History> histories = await repo.GetAllHistories();
                return Ok(histories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// List of histories by priority id for given user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="priorityId"></param>
        /// <returns Get history by priority></returns>
        [HttpGet("ByPriorityId/{userId}/{priorityId}")]
        public async Task<ActionResult> GetByPriorityId(int userId, int priorityId)
        {
            try
            {
                List<History> histories = await repo.GetHistoriesByPriorityId(userId,priorityId);
                return Ok(histories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// List of histories by status id for given user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="statusId"></param>
        /// <returns Get history for given status></returns>
        [HttpGet("ByStatusId/{userId}/{statusId}")]
        public async Task<ActionResult> GetByStatusId(int userId,int statusId)
        {
            try
            {
                List<History> histories = await repo.GetHistoriesByStatusId(userId, statusId);
                return Ok(histories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// List of histories by task id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns List of history for given task></returns>
        [HttpGet("ByTaskId/{userid}/{taskid}")]
        public async Task<ActionResult> GetByTaskId(int userId, int taskId)
        {
            try
            {
                List<History> histories = await repo.GetHistoriesByTaskId(userId, taskId);
                return Ok(histories);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// List of history for given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns List of history for given user></returns>
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
            try
            {
                List<History> histories = await repo.GetHistoriesByUserId(userId);
                return Ok(histories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
