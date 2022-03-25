using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Project.Areas.Admin.ViewModel
{
    public class OrderDetailViewModel
    {
        public int Order_Detail_Id { get; set; }
        public string Product_name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public  int  Total { get; set; }


    }
}
