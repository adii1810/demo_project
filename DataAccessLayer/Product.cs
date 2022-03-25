using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Price { get; set; }
        public string Description { get; set; }
        public Sub_Category Sub_Category { get; set; }
        public Restaurant_Detail Restaurant_Detail { get; set; }
        public ICollection<User_Rating> User_Ratings { get; set; } = new HashSet<User_Rating>();
        public ICollection<User_Review> User_Reviews { get; set; } = new HashSet<User_Review>();
        public bool Product_Status { get; set; }

    }

    public enum FoodType { 
        veg=0,
        nonveg = 1,
        vegan = 2
    }
}