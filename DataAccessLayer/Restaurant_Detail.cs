using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
   public class Restaurant_Detail
    {
        [Key]
        public int Restaurant_Detail_Id { get; set; }
        public string Restaurant_Detail_Name { get; set; }
        public string Restaurant_Detail_User_Name { get; set; }
        public string Restaurant_Detail_Password { get; set; }
        public string Restaurant_Detail_Address { get; set; }
        public string Restaurant_Detail_PhoneNo { get; set; }
        public string Restaurant_Detail_Email { get; set; }
        public string Restaurant_Detail_City { get; set; }
        public string Restaurant_Detail_State { get; set; }
        public string Restaurant_Detail_Zipcode { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
