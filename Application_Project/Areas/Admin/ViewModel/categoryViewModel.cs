using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Project.Areas.Admin.ViewModel
{
    public class categoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public List<SelectListItem> Categories { get; set; }
        
    }
    //public enum Main
    //{
    //    Food = 0,
    //    Beverage = 1,
    //    Desert = 2
    //}
}
