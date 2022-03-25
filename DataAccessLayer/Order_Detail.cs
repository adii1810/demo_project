using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
   public class Order_Detail
    {

        
        public int Order_Detail_Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}