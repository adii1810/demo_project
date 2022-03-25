using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
       
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Detail> Order_Detail { get; set; }
        
        public DbSet<Restaurant_Detail> Restaurant_Detail { get; set; }
        public DbSet<Sub_Category> Sub_Categorie { get; set; }
        public DbSet<User_Data> User_Data { get; set; }
        public DbSet<User_Rating> User_Rating { get; set; }
        public DbSet<User_Review> User_Review { get; set; }
        public DbSet<Valet> Valet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Data>().HasData(
                new User_Data {User_Id=1,User_FirstName = "aditya",User_Address="Surat",User_City="surat",User_Email="admin@admin.com",User_LastName="neve",User_Password="admin123",User_PhoneNo="8469712459",User_UserName="Admin" }
                );
           // modelBuilder.Entity<Order_Detail>().HasNoKey();
          modelBuilder.Entity<Order_Detail>().HasKey(t => new { t.Order_Detail_Id, t.OrderId });
          //  modelBuilder.Entity<Order_Detail>().Property(p => p.Order_Detail_Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
