using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Sub_Category
    {
        [Key]
        public int Sub_Category_Id { get; set; }
        public Main Main_Category_Id { get; set; }
        public string Sub_Category_Name { get; set; }

       
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }

    public enum Main
    {
        Food = 0,
        Beverage =1,
        Desert = 2
    }
}