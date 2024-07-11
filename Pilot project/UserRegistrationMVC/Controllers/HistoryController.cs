using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLibrary.Models;

namespace TaskListMVC.Controllers
{
    /// <summary>
    /// It will control the whole history table that will add and show the task in history
    /// </summary>
    public class HistoryController : Controller
    {
        static HttpClient svc = new HttpClient { BaseAddress = new Uri("http://localhost:5057/api/History/") };

        /// <summary>
        /// For setting session for common method
        /// </summary>
        public void SetSession()
        {
            ViewBag.displayname = HttpContext.Session.GetString("displayname");
            ViewBag.userid = HttpContext.Session.GetInt32("userid");
        }
        /// <summary>
        /// Get all history list for given user
        /// </summary>
        /// <returns List of all task lists for given user></returns>
        public async Task <ActionResult> Index()
        {
            SetSession();
            int userId = ViewBag.userid;
            List<History> tasks = await svc.GetFromJsonAsync<List<History>>("" + "ByUserId/" + userId);
            return View(tasks);
        }

        /// <summary>
        /// For selecting priority to show the history
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetByPriorityIndex()
        {
            SetSession();
            return View();
        }

        /// <summary>
        /// List of history for given priority
        /// </summary>
        /// <param name="priorityId"></param>
        /// <returns List of task list by given priority></returns>
        public async Task<ActionResult> GetByPriority(int priorityId)
        {
            try
            {
                SetSession();
                int userId=ViewBag.userid;
                List<History> histories = await svc.GetFromJsonAsync<List<History>>("" + "ByPriorityId/" +userId+"/"+ priorityId);
                return View(histories);
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// For selecting priority to show the history
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GetByStatusIndex()
        {
            SetSession();
            return View();
        }

        /// <summary>
        /// List of history for given status
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns List of task list by given status></returns>
        public async Task<ActionResult> GetByStatus(int statusId)
        {
            try
            {
                SetSession();
                int userId=ViewBag.userid;
                List<History> histories = await svc.GetFromJsonAsync<List<History>>("" + "ByStatusId/" +userId+"/"+ statusId);
                return View(histories);
            }
            catch
            {
                return View();
            }
        }
    }
}
