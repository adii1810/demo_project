using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ValetId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ValetId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Valet_Id",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Valet_Id",
                table: "Order",
                column: "Valet_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Valet_Valet_Id",
                table: "Order",
                column: "Valet_Id",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Valet_Valet_Id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_Valet_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "VId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Valet_Id",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValetId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ValetId",
                table: "Order",
                column: "ValetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order",
                column: "ValetId",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
