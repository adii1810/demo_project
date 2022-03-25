using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.ViewModel
{
    public class OrderViewModel
    {
        public int Order_Id { get; set; }
        public string Order_Date { get; set; }

        public int Valet_id { get; set; }
        public int Total { get; set; }

       // public List<SelectListItem> QuantityLists { get; set; }
    }
}
