using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using TaskLibrary.Models;

namespace TaskListMVC.Controllers
{
    /// <summary>
    /// Whole task list table is managed by this controller. Here we can add,edit,delete,get all the work can be done
    /// </summary>
    public class TaskManagerController : Controller
    {
        static HttpClient svc = new HttpClient { BaseAddress = new Uri("http://localhost:5057/api/TaskList/") };

        /// <summary>
        /// For setting session for common
        /// </summary>
        public void SetSession()
            {
                ViewBag.displayname = HttpContext.Session.GetString("displayname");
                ViewBag.userid = HttpContext.Session.GetInt32("userid");
            }

        /// <summary>
        /// Get all lists for given user
        /// </summary>
        /// <returns List of task for given user></returns>
        public async Task<ActionResult> Index()
        {
            SetSession();
            int userid=ViewBag.userid;
            List<TaskList> tasks = await svc.GetFromJsonAsync<List<TaskList>>(""+"ByUserId/"+userid);
            return View(tasks);
        }

        /// <summary>
        /// Get details for particular task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns Details of particular task></returns>
        public async Task <ActionResult> Details(int taskId)
        {
            SetSession();
            TaskList list = await svc.GetFromJsonAsync<TaskList>(""+"ByTaskId/"+taskId);
            return View(list);
        }

        /// <summary>
        /// Creating the new task
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SetSession();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TaskList taskList)
        {
            try
            {
                SetSession();
                taskList.UserId = ViewBag.userid;
                taskList.CreatedBy = taskList.UserId;
                taskList.CreatedOn = DateTime.Now;               
                await svc.PostAsJsonAsync("", taskList);
                TempData["SuccessCreate"] = true;
                return RedirectToAction(nameof(Index));                 
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Edit the existing task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [Route("TaskList/Edit/{taskId}")]
        public async Task <ActionResult> Edit(int taskId)
        {
            SetSession();
            TaskList task = await svc.GetFromJsonAsync<TaskList>(""+"ByTaskId/"+taskId);
            return View(task);
        }
        [Route("TaskList/Edit/{taskId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int taskId,TaskList task)
        {
            try
            {
                SetSession();
                await svc.PutAsJsonAsync<TaskList>($"{taskId}", task);
                TempData["SuccessUpdate"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Delete the task by changing the status id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [Route("TaskList/Delete/{taskId}")]
        public async Task <ActionResult> Delete(int taskId)
        {
            SetSession();
            TaskList task = await svc.GetFromJsonAsync<TaskList>("" + "ByTaskId/" + taskId);
            return View(task);
        }
        [Route("TaskList/Delete/{taskId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int taskId,TaskList task)
        {
            try
            {
                SetSession();
                await svc.DeleteAsync($"{taskId}");
                TempData["SuccessDelete"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// To select status type to show list
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetByStatusIndex()
        {
            SetSession();
            return View();
        }

        /// <summary>
        /// List of task for given status
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns List of task for given status></returns>
        public async Task<ActionResult> GetByStatus(int statusId)
        {
            try
            {
                SetSession();
                int userId=ViewBag.userid;
                List<TaskList> list = await svc.GetFromJsonAsync<List<TaskList>>("" + "ByStatus/" +userId+"/"+ statusId);
                return View(list);
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// To select priority type to show list
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetByPriorityIndex()
        {
            SetSession();
            return View();
        }

        /// <summary>
        /// List of task for given priority
        /// </summary>
        /// <param name="priorityId"></param>
        /// <returns List of status for given priority></returns>
        public async Task<ActionResult> GetByPriority(int priorityId)
        {
            try
            {
                SetSession();
                int userId = ViewBag.userid;
                List<TaskList> list = await svc.GetFromJsonAsync<List<TaskList>>("" + "ByPriority/" + userId+"/"+priorityId);
                return View(list);
            }
            catch 
            { 
                return View(); 
            }
        }

        /// <summary>
        /// To select task date to show list
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetByTaskDateIndex()
        {
            SetSession();
            return View();
        }

        /// <summary>
        /// List of task for given task date
        /// </summary>
        /// <param name="taskDate"></param>
        /// <returns List of task for given task date></returns>
        public async Task<ActionResult> GetByTaskDate(DateOnly taskDate)
        {
            try
            {
                SetSession();
                int userId = ViewBag.userid;
                List<TaskList> list = await svc.GetFromJsonAsync<List<TaskList>>("" + "ByDate/" + userId + "/" + taskDate);
                return View(list);
            }
            catch
            {
                return View();
            }
        }
    }
}
