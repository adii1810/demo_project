using DataAccessLayer;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
   public interface IAdminInterface
    {
        public int AdminLogin(string user, string pass);
        public Task<IEnumerable<User_Data>> ShowUser();
        public Task<IEnumerable<OrderViewModel>> OrderPerUser(int UserId);
        public Task<IEnumerable<OrderDetailViewModel>> OrderDetailsPerUser(int OrderId);
        public IList<SelectListItem> AutocompleteMainCategory();
        public IEnumerable<SubViewModel> AutocompleteSubCategory(int mainId);


    }
}
