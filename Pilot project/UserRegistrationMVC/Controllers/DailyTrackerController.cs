using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskLibrary.Models;

namespace TaskListMVC.Controllers
{
    /// <summary>
    /// In this daily tracker controller it will show the list available for todays date
    /// </summary>
    public class DailyTrackerController : Controller
    {

        static HttpClient svc = new HttpClient { BaseAddress = new Uri("http://localhost:5057/api/TaskList/") };

        /// <summary>
        /// Daily tracker task details for today date
        /// </summary>
        /// <returns List of task list for today date> </returns>
        public async Task<ActionResult> GetDetailsByTaskDate()
        {

            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            ViewBag.userid = HttpContext.Session.GetInt32("userid");
            ViewBag.displayname = HttpContext.Session.GetString("displayname");
            int userId=ViewBag.userid;
            string formattedDate = today.ToString("dd-MM-yyyy");
            List<TaskList> lists = await svc.GetFromJsonAsync<List<TaskList>>("" + "ByDate/" +userId+"/"+ formattedDate);
            return View(lists);
        }
    }
}
