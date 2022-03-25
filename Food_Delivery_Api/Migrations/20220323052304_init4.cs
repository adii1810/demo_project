using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_Data_User_DataUser_Id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_User_DataUser_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "User_DataUser_Id",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UserDataUser_Id",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserDataUser_Id",
                table: "Order",
                column: "UserDataUser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_Data_UserDataUser_Id",
                table: "Order",
                column: "UserDataUser_Id",
                principalTable: "User_Data",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_Data_UserDataUser_Id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserDataUser_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserDataUser_Id",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "User_DataUser_Id",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_DataUser_Id",
                table: "Order",
                column: "User_DataUser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_Data_User_DataUser_Id",
                table: "Order",
                column: "User_DataUser_Id",
                principalTable: "User_Data",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
