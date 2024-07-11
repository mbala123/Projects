using LoginFormLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;

namespace RegisterMvc.Controllers
{
    public class RegisterController : Controller
    {
        static HttpClient svc = new HttpClient { BaseAddress = new Uri("http://localhost:5058/Register/") };
        // GET: RegisterController
        public async Task <ActionResult> Index()
        {
            var username = HttpContext.Session.GetString("username");
            var name = HttpContext.Session.GetString("EmployeeName");
            ViewBag.username = username;
            ViewBag.EmployeeName = name;
            List<Register> reg = await svc.GetFromJsonAsync<List<Register>>("");
            return View(reg);
        }

        public ActionResult Login()
        {
            ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Verify(string username, string password)
        {

            HttpResponseMessage response = await svc.GetAsync(username);
            if (response.IsSuccessStatusCode)
            {

                Register reg = await response.Content.ReadFromJsonAsync<Register>();
                if (reg.username == username && reg.psword == password)
                {

                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("EmployeeName", reg.EmployeeName);
                    return RedirectToAction("Index", "Register");
                }
                else
                {

                    TempData["ErrorMessage"] = "Invalid username or password.";
                    return RedirectToAction("Login", "Register");

                }
            }
            else
            {
                return View("Error");
            }

            return View("Login");

        }

        // GET: RegisterController/Details/5
        public async Task <ActionResult> Details(int id)
        {
          
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Register(Register r)
        {
            try
            {
                await svc.PostAsJsonAsync<Register>("", r);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
       
        public async Task <ActionResult> Edit(int id)
        {
           
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(string username,Register r)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
