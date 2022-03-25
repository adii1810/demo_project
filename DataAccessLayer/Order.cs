using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
   public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int User_DataId { get; set; }
        public int ValetId { get; set; }
        public OrderStatus Order_Status_Id { get; set; }
        public User_Data User_Data { get; set; }
        public Valet Valet { get; set; }
       // public ICollection<Order_Detail> Order_Details { get; set; } = new HashSet<Order_Detail>();
    }

    public enum OrderStatus
    {
        Product_Delivered = 0,
        On_the_way = 1,
        Delivered_Success = 2
    }
}