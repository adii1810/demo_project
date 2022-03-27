using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Project.Areas.Admin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace My_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
       
        // GET: AdminController
        //public ActionResult Index()
        //{
        //    return View();
        //}
       
        public async Task<ActionResult> ShowUser()
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:39658");
            HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/ShowUser");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<UserDataViewModel> data = new List<UserDataViewModel>();
                data = JsonConvert.DeserializeObject<List<UserDataViewModel>>(result);
                return View(data);
            }
            return View();
            //  }
        }
        
        public async Task<ActionResult> ShowOrders(int Id)
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:39658");
            HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/ShowOrder/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<OrderViewModel> data = new List<OrderViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
                return View(data);
            }
            return View();
            //  }
        }
        public async Task<ActionResult> ShowOrdersDetails(int Id,int total)
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:39658");
            HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/ShowOrderDetails/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<OrderDetailViewModel> data = new List<OrderDetailViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(result);
                ViewBag.total = total;
                return View(data);
            }
            return View();
            //  }
        }
        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
