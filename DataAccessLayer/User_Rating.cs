using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
   public class User_Rating
    {
        [Key]
        public int User_Rating_Id { get; set; }
        public int User_Rating_Star { get; set; }
        public Product Product { get; set; }
        public User_Data User_Data { get; set; }

    }
}
