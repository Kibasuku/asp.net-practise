using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Migrations
{
    public partial class AddOthersModelsToDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_orderId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_orderId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderId1",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_orderId",
                table: "Goods",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Orders_orderId",
                table: "Goods",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Orders_orderId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_orderId",
                table: "Goods");

            migrationBuilder.AddColumn<int>(
                name: "orderId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderId1",
                table: "Orders",
                column: "orderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_orderId1",
                table: "Orders",
                column: "orderId1",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
