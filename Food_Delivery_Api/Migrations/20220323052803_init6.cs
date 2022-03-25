using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_Data_UserDataUser_Id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Valet_Valet_Id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserDataUser_Id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_Valet_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserDataUser_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "VId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Valet_Id",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "User_DataId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValetId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_DataId",
                table: "Order",
                column: "User_DataId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ValetId",
                table: "Order",
                column: "ValetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_Data_User_DataId",
                table: "Order",
                column: "User_DataId",
                principalTable: "User_Data",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order",
                column: "ValetId",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_Data_User_DataId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_User_DataId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ValetId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "User_DataId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ValetId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDataUser_Id",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Valet_Id",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserDataUser_Id",
                table: "Order",
                column: "UserDataUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Valet_Id",
                table: "Order",
                column: "Valet_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_Data_UserDataUser_Id",
                table: "Order",
                column: "UserDataUser_Id",
                principalTable: "User_Data",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Valet_Valet_Id",
                table: "Order",
                column: "Valet_Id",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
