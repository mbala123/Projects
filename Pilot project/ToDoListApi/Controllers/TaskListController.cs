using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TaskLibrary.Models;
using TaskLibrary.Repos;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        //Dependency injection
        ITaskList repo;
        public TaskListController(ITaskList task)
        {
            repo = task;
        }

        /// <summary>
        /// Get all task lists
        /// </summary>
        /// <returns List of all task></returns>
        [HttpGet]
        public async Task <ActionResult> GetAllLists()
        {
            try
            {
                List<TaskList> list = await repo.GetAllLists();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all task by given status
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="statusId"></param>
        /// <returns List of all task for given status></returns>
        [HttpGet("ByStatus/{userId}/{statusId}")]
        public async Task <ActionResult> GetByStatus(int userId, int statusId)
        {
            try
            {
                List<TaskList> list = await repo.GetListsByStatus(userId,statusId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all task by given priority
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="priorityId"></param>
        /// <returns List of all task for given priority></returns>
        [HttpGet("ByPriority/{userId}/{priorityId}")]
        public async Task<ActionResult> GetByPriority(int userId, int priorityId)
        {
            try
            {
                List<TaskList> list = await repo.GetListsByPriority(userId, priorityId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all task by given task date
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="today"></param>
        /// <returns List of all task for given task date></returns>
        [HttpGet("ByDate/{userId}/{today}")]
        public async Task <ActionResult> GetByTaskDate(int userId,string today)
        {
            try
            {
                DateTime parsedDate;
                if (!DateTime.TryParseExact(today, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    // Handle invalid date format
                    return BadRequest("Invalid date format. Please use dd-MM-yyyy format.");
                }
                DateOnly dateOnly = DateOnly.FromDateTime(parsedDate);
                List<TaskList> list = await repo.GetListsByTaskDate(userId,dateOnly);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all task by given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns Get all task list for given user></returns>
        [HttpGet("ByUserId/{userId}")]
        public async Task <ActionResult> GetByUserId(int userId)
        {
            try
            {
                List<TaskList> list = await repo.GetListsByUserId(userId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get details of given task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns Details of the particular task></returns>
        [HttpGet("ByTaskId/{taskId}")]
        public async Task<ActionResult> GetByTaskId(int taskId)
        {
            try
            {
                TaskList task = await repo.GetOne(taskId);
                return Ok(task);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insert new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> InsertTask(TaskList task)
        {
            try
            {
                await repo.InsertNewTask(task);
                return Created($"api/TaskList/{task.TaskId}", task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update the existing task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut("{taskId}")]
        public async Task<ActionResult> UpdateTask(int taskId,TaskList task)
        {
            try
            {
                await repo.UpdateTask(taskId, task);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete("{taskId}")]
        public async Task<ActionResult> DeleteTask(int taskId)
        {
            try
            {
                await repo.DeleteTask(taskId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
