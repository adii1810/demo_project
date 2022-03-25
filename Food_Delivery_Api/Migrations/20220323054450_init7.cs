using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Detail_Product_Product_Id",
                table: "Order_Detail");

            migrationBuilder.DropIndex(
                name: "IX_Order_Detail_Product_Id",
                table: "Order_Detail");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Order_Detail");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order_Detail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_ProductId",
                table: "Order_Detail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Detail_Product_ProductId",
                table: "Order_Detail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Detail_Product_ProductId",
                table: "Order_Detail");

            migrationBuilder.DropIndex(
                name: "IX_Order_Detail_ProductId",
                table: "Order_Detail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order_Detail");

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Order_Detail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_Product_Id",
                table: "Order_Detail",
                column: "Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Detail_Product_Product_Id",
                table: "Order_Detail",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
