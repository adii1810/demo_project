using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant_Detail",
                columns: table => new
                {
                    Restaurant_Detail_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Detail_Name = table.Column<string>(nullable: true),
                    Restaurant_Detail_User_Name = table.Column<string>(nullable: true),
                    Restaurant_Detail_Password = table.Column<string>(nullable: true),
                    Restaurant_Detail_Address = table.Column<string>(nullable: true),
                    Restaurant_Detail_PhoneNo = table.Column<string>(nullable: true),
                    Restaurant_Detail_Email = table.Column<string>(nullable: true),
                    Restaurant_Detail_City = table.Column<string>(nullable: true),
                    Restaurant_Detail_State = table.Column<string>(nullable: true),
                    Restaurant_Detail_Zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant_Detail", x => x.Restaurant_Detail_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Categorie",
                columns: table => new
                {
                    Sub_Category_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main_Category_Id = table.Column<int>(nullable: false),
                    Sub_Category_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categorie", x => x.Sub_Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Data",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_FirstName = table.Column<string>(nullable: true),
                    User_LastName = table.Column<string>(nullable: true),
                    User_UserName = table.Column<string>(nullable: true),
                    User_Password = table.Column<string>(nullable: true),
                    User_Address = table.Column<string>(nullable: true),
                    User_PhoneNo = table.Column<string>(nullable: true),
                    User_Email = table.Column<string>(nullable: true),
                    User_City = table.Column<string>(nullable: true),
                    User_State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Data", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Valet",
                columns: table => new
                {
                    Valet_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valet_Name = table.Column<string>(nullable: true),
                    Valet_Address = table.Column<string>(nullable: true),
                    Valet_UserName = table.Column<string>(nullable: true),
                    Valet_Password = table.Column<string>(nullable: true),
                    Valet_Email = table.Column<string>(nullable: true),
                    Valet_PhoneNo = table.Column<string>(nullable: true),
                    Valet_City = table.Column<string>(nullable: true),
                    Valet_State = table.Column<string>(nullable: true),
                    Valet_Zipcode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valet", x => x.Valet_Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(nullable: true),
                    Product_Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Sub_Category_Id = table.Column<int>(nullable: true),
                    Restaurant_Detail_Id = table.Column<int>(nullable: true),
                    Product_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Product_Restaurant_Detail_Restaurant_Detail_Id",
                        column: x => x.Restaurant_Detail_Id,
                        principalTable: "Restaurant_Detail",
                        principalColumn: "Restaurant_Detail_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Sub_Categorie_Sub_Category_Id",
                        column: x => x.Sub_Category_Id,
                        principalTable: "Sub_Categorie",
                        principalColumn: "Sub_Category_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date = table.Column<DateTime>(nullable: false),
                    Order_Status_Id = table.Column<int>(nullable: false),
                    User_DataUser_Id = table.Column<int>(nullable: true),
                    Valet_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Order_User_Data_User_DataUser_Id",
                        column: x => x.User_DataUser_Id,
                        principalTable: "User_Data",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Valet_Valet_Id",
                        column: x => x.Valet_Id,
                        principalTable: "Valet",
                        principalColumn: "Valet_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Rating",
                columns: table => new
                {
                    User_Rating_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Rating_Star = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: true),
                    User_DataUser_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Rating", x => x.User_Rating_Id);
                    table.ForeignKey(
                        name: "FK_User_Rating_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Rating_User_Data_User_DataUser_Id",
                        column: x => x.User_DataUser_Id,
                        principalTable: "User_Data",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Review",
                columns: table => new
                {
                    User_Review_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Review_Comment = table.Column<string>(nullable: true),
                    Product_Id = table.Column<int>(nullable: true),
                    User_DataUser_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Review", x => x.User_Review_Id);
                    table.ForeignKey(
                        name: "FK_User_Review_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Review_User_Data_User_DataUser_Id",
                        column: x => x.User_DataUser_Id,
                        principalTable: "User_Data",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Detail",
                columns: table => new
                {
                    Order_Detail_Id = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Product_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Detail", x => new { x.Order_Detail_Id, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Order_Detail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Detail_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User_Data",
                columns: new[] { "User_Id", "User_Address", "User_City", "User_Email", "User_FirstName", "User_LastName", "User_Password", "User_PhoneNo", "User_State", "User_UserName" },
                values: new object[] { 1, "Surat", "surat", "admin@admin.com", "aditya", "neve", "admin123", "8469712459", null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_DataUser_Id",
                table: "Order",
                column: "User_DataUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Valet_Id",
                table: "Order",
                column: "Valet_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_OrderId",
                table: "Order_Detail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Product_Id",
                table: "Order_Detail",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Restaurant_Detail_Id",
                table: "Product",
                column: "Restaurant_Detail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Sub_Category_Id",
                table: "Product",
                column: "Sub_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Rating_Product_Id",
                table: "User_Rating",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Rating_User_DataUser_Id",
                table: "User_Rating",
                column: "User_DataUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Review_Product_Id",
                table: "User_Review",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Review_User_DataUser_Id",
                table: "User_Review",
                column: "User_DataUser_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Detail");

            migrationBuilder.DropTable(
                name: "User_Rating");

            migrationBuilder.DropTable(
                name: "User_Review");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User_Data");

            migrationBuilder.DropTable(
                name: "Valet");

            migrationBuilder.DropTable(
                name: "Restaurant_Detail");

            migrationBuilder.DropTable(
                name: "Sub_Categorie");
        }
    }
}
