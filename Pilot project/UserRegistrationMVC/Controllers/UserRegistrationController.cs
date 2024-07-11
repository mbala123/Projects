using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Win32;
using TaskLibrary.Models;

namespace TaskListMVC.Controllers
{
    /// <summary>
    /// All users can register,login and logout can be done
    /// </summary>
    public class UserRegistrationController : Controller
    {
        static HttpClient svc = new HttpClient { BaseAddress = new Uri("http://localhost:5057/api/UserRegistration/") };

        /// <summary>
        /// List of all users
        /// </summary>
        /// <returns List of all user></returns>
        public async Task <ActionResult> Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.displayname = HttpContext.Session.GetString("displayname");
            List<UserRegistration> reg = await svc.GetFromJsonAsync<List<UserRegistration>>("");
            return View(reg);
        }

        /// <summary>
        /// For login view
        /// </summary>
        /// <returns Login view></returns>
        public async Task <ActionResult> Login()
        {
            ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            return View();
        }

        /// <summary>
        /// Verify for the username and password to login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Verify(string userName, string password)
        {
            HttpResponseMessage response = await svc.GetAsync($"Byusername/{userName}");
            if (response.IsSuccessStatusCode)
            {
                UserRegistration reg = await response.Content.ReadFromJsonAsync<UserRegistration>();
                if (reg.UserName == userName && reg.Password == password)
                {
                    HttpContext.Session.SetString("IsLogin", "true");
                    HttpContext.Session.SetString("displayname", reg.DisplayName);
                    HttpContext.Session.SetInt32("userid", reg.UserId);
                    TempData["LoginSuccess"] = true;
                    return RedirectToAction("Index", "Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Password does not match";
                    return RedirectToAction("Login", "UserRegistration");
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid Username";
            }
            return View("Login");
        }

        /// <summary>
        /// For logout the existing user
        /// </summary>
        /// <returns></returns>
        public async Task <ActionResult> Logout()
        {
            HttpContext.Session.Remove("IsLogin");
            HttpContext.Session.Remove("displayname");
            HttpContext.Session.Remove("userid");
            TempData["LogoutSuccess"] = true;
            return RedirectToAction("Login", "UserRegistration");
        }

        /// <summary>
        /// Register for new user view
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Register(UserRegistration register)
        {
            try
            {
                string userName = register.UserName;
                HttpResponseMessage response = await svc.GetAsync($"Byusername/{userName}");
                if (response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty,"User Name already exists");                   
                    return View("Register",register);
                }
                else
                {
                    await svc.PostAsJsonAsync<UserRegistration>("", register);
                    TempData["RegisterSuccess"] = true;
                    return RedirectToAction(nameof(Login));                    
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
