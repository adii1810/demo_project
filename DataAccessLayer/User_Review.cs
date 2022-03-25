using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class User_Review
    {
        [Key]
        public int User_Review_Id { get; set; }
        public string User_Review_Comment { get; set; }
        public Product Product { get; set; }
        public User_Data User_Data { get; set; }
    }
}