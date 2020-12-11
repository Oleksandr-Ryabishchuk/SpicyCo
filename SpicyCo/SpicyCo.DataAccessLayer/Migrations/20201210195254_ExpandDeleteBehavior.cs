using Microsoft.EntityFrameworkCore.Migrations;

namespace SpicyCo.DataAccessLayer.Migrations
{
    public partial class ExpandDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Products_ProductId",
                table: "Fields");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Products_ProductId",
                table: "Fields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Products_ProductId",
                table: "Fields");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Products_ProductId",
                table: "Fields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
