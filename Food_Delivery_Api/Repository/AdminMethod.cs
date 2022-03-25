using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public class AdminMethod : IAdminInterface
    {
        private readonly ApplicationDbContext _context;
        public AdminMethod(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AdminLogin(string user, string pass)
        {
            var Data =  _context.User_Data.Where(x => x.User_UserName == user && x.User_Password == pass).Count();
            return Data;
        }

        public IList<SelectListItem> AutocompleteMainCategory()
        {
            var data = Enum.GetValues(typeof(Main)).Cast<Main>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            }).ToList();
           
            return data;
        }

        public IEnumerable<SubViewModel> AutocompleteSubCategory(int mainId)
        {
            var data = _context.Sub_Categorie.Where(x => (int)x.Main_Category_Id == mainId).Select(x=> new { 
            x.Sub_Category_Id,
            x.Sub_Category_Name
            }).ToList();
            List<SubViewModel> l = new List<SubViewModel>();
            foreach (var item in data)
            {
                SubViewModel vm = new SubViewModel();
                vm.sub_Category_Id = item.Sub_Category_Id;
                vm.Sub_Category_Name = item.Sub_Category_Name;

                l.Add(vm);
            }
            return l;
        }

        public async Task<IEnumerable<OrderDetailViewModel>> OrderDetailsPerUser(int OrderId)
        {
            List<OrderDetailViewModel> ol = new List<OrderDetailViewModel>();
            var data = await _context.Order_Detail.Where(x => x.OrderId == OrderId).ToListAsync();
            foreach (var item in data)
            {
                OrderDetailViewModel vm = new OrderDetailViewModel();
                vm.Order_Detail_Id = item.Order_Detail_Id;
                vm.Quantity = item.Quantity;
                var data1 = _context.Product.Where(x => x.Product_Id == item.ProductId).FirstOrDefault();
                vm.Product_name = data1.Product_Name;
                vm.Price = data1.Product_Price * item.Quantity ;

                ol.Add(vm);
            }
            return ol;
        }

        public async Task<IEnumerable<OrderViewModel>> OrderPerUser(int UserId)
        {
            List<OrderViewModel> ol = new List<OrderViewModel>();
            var data = await _context.Order.Where(x => x.User_DataId == UserId).OrderByDescending(x=>x.Order_Id).ToListAsync();

            foreach (var item in data)
            {
                OrderViewModel vm = new OrderViewModel();
                vm.Order_Id = item.Order_Id;
                vm.Order_Date = item.Order_Date.ToString("d");
                vm.Valet_id = item.ValetId;
                var data2 = _context.Order_Detail.Where(x => x.OrderId == item.Order_Id).ToList();
                int sum = 0;
                foreach (var item2 in data2)
                {
                    int price = _context.Product.Where(x => x.Product_Id == item2.ProductId).Select(x => x.Product_Price).FirstOrDefault();
                    sum += price * item2.Quantity;
                }
                vm.Total = sum;
                ol.Add(vm);
                sum = 0;
            }
            return ol;
        }

        public async Task<IEnumerable<User_Data>> ShowUser()
        {
            var data = await _context.User_Data.OrderByDescending(x => x.User_Id).ToListAsync();
            return data;
        }
    }
}
