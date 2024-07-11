using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskListMVC.Controllers
{
    public class IndexController : Controller
    {
        /// <summary>
        /// Menu controller to select options
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           ViewBag.username = HttpContext.Session.GetString("username");
           ViewBag.displayname = HttpContext.Session.GetString("displayname");
           return View();
        }

    }
}
