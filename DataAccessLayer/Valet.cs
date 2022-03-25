using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Valet
    {
        [Key]
        public int Valet_Id { get; set; }
        public string Valet_Name { get; set; }
        public string Valet_Address { get; set; }
        public string Valet_UserName { get; set; }
        public string Valet_Password { get; set; }
        public string Valet_Email { get; set; }
        public string Valet_PhoneNo { get; set; }
        public string Valet_City { get; set; }
        public string Valet_State { get; set; }
        public string Valet_Zipcode { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
