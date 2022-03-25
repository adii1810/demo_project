using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.ViewModel
{
    public class OrderDetailViewModel
    {
        public int Order_Detail_Id { get; set; }
        public string Product_name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }


    }
}
