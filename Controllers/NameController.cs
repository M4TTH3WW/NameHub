using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NameHub.Models;
using Newtonsoft.Json;
using System.Text;

namespace NameHub.Controllers
{
    public class NameController : Controller
    {
        // GET: NameController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7185/api/Info";

            List<Namesmodel> users = new List<Namesmodel>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<Namesmodel>>(result);
            }

            return View(users);
        }

        // GET: NameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Namesmodel user)
        {
            string apiUrl = "https://localhost:7185/api/Info";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // GET: NameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NameController/Edit/5
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

        // GET: NameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NameController/Delete/5
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
