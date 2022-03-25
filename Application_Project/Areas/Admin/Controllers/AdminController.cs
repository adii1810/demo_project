using Application_Project.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Application_Project.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str == null)
                return RedirectToAction("AdminLogin");
            return View();
        }

        // Show All User
        public async Task<ActionResult> ShowUser()
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str != null)
            {
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
            }
            return RedirectToAction("AdminLogin");
        }
        public async Task<ActionResult> ShowOrders(int UId)
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/ShowOrder/{UId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<OrderViewModel> data = new List<OrderViewModel>();
                    data = JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
                    return View(data);
                }
            }
            return RedirectToAction("AdminLogin");
        }

        public async Task<ActionResult> ShowOrdersDetails(int OId,int total)
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/ShowOrderDetails/{OId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<OrderDetailViewModel> data = new List<OrderDetailViewModel>();
                    data = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(result);
                    
                    ViewBag.total = total;
                    
                    return View(data);
                }
            }
            return RedirectToAction("AdminLogin");
        }

        public async Task<ActionResult> ShowOrdersDetails1(int OId, int total)
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/ShowOrderDetails/{OId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<OrderDetailViewModel> data = new List<OrderDetailViewModel>();
                    data = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(result);

                    ViewBag.total = total;

                    return View(data);
                }
            }
            return RedirectToAction("AdminLogin");
        }

        [HttpGet]
        public async Task<ActionResult> ShowProduct()
        {
            categoryViewModel vm = new categoryViewModel();
            var str = HttpContext.Session.GetString("Admin");
            if (str != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/Category");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<SelectListItem> enums = new List<SelectListItem>();
                    enums = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                    vm.Categories = enums;
                    return View(vm);
                }
            }
            return RedirectToAction("AdminLogin");
//            var data =  Enum.GetValues(typeof(Main)).Cast<Main>().Select(x=> new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() })
//.ToList();
//            vm.Categories = data;
       
//            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> ShowProduct(int mainId)
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str != null)
            {
                
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/SubCategory?mainId={mainId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    List<subCategoryViewModel> vm1 = new List<subCategoryViewModel>();
                    // List<SelectListItem> enums = new List<SelectListItem>();
                    vm1 = JsonConvert.DeserializeObject<List<subCategoryViewModel>>(result);
                    //ViewBag.data = vm1[0].Id;
                    return View(vm1);
                }
            }
            return RedirectToAction("AdminLogin");

           
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
        public async Task<ActionResult> AdminLogin()
        {
            return View();
        }

        public async Task<ActionResult> AutoCompleteMainCategory(string Value)
        {


            return View();
        }













        [HttpPost]
        public async Task<ActionResult> AdminLogin(string User,string Pass)
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str == null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/Login?user={User}&pass={Pass}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    if (result == "true")
                    {
                        HttpContext.Session.SetString("Admin", User);
                        return RedirectToAction("Index");

                    }
                }
                return View();
            }
            return RedirectToAction("Index");
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
