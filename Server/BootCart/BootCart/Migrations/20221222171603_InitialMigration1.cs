using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCart.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSpecificationId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductSpecificationId",
                table: "OrderItems",
                column: "ProductSpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductSpecifications_ProductSpecificationId",
                table: "OrderItems",
                column: "ProductSpecificationId",
                principalTable: "ProductSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductSpecifications_ProductSpecificationId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductSpecificationId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductSpecificationId",
                table: "OrderItems");
        }
    }
}
