using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class User_Data
    {
        [Key]
        public int User_Id { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_UserName { get; set; }
        public string User_Password { get; set; }
        public string User_Address { get; set; }
        public string User_PhoneNo { get; set; }
        public string User_Email { get; set; }
        public string User_City { get; set; }
        public string User_State { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<User_Rating> User_Ratings { get; set; } = new HashSet<User_Rating>();
        public ICollection<User_Review> User_Reviews { get; set; } = new HashSet<User_Review>();


    }
}
