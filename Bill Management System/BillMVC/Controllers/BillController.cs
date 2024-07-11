using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using BillLibrary.Models;

namespace BillMVC.Controllers
{
    public class BillController : Controller
    {
        static HttpClient svc = new HttpClient { BaseAddress = new Uri("http://localhost:5173/api/BillItem/") };
        static HttpClient svc1 = new HttpClient { BaseAddress = new Uri("http://localhost:5173/api/UserDetails/") };


        // GET: BillController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BillController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BillController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDetails userDetails, List<BillItems> billItems)
        {
            try
            {
               
                userDetails.Bills = billItems;                
              //  var json = JsonSerializer.Serialize(userDetails);
              //  var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await svc1.PostAsJsonAsync("", userDetails);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: BillController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BillController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillController/Delete/5
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
